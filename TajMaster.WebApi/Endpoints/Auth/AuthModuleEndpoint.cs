using System.IdentityModel.Tokens.Jwt;
using Carter;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.IdentityService;

namespace TajMaster.WebApi.Endpoints.Auth;

public class AuthModuleEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/refresh-token", async (HttpContext context) =>
            {
                try
                {
                    if (!context.Request.Cookies.ContainsKey("RefreshToken")) return Results.Unauthorized();

                    var rawHeader = context.Request.Headers["Authorization"].FirstOrDefault();

                    if (string.IsNullOrEmpty(rawHeader) || !rawHeader.StartsWith("Bearer "))
                    {
                        Console.WriteLine("Authorization header is missing or invalid.");

                        throw new InvalidOperationException();
                    }

                    var accessToken = rawHeader.Substring("Bearer ".Length).Trim(); // Extract the token
                    Console.WriteLine($"Parsed Access Token: {accessToken}");


                    var tokenService = context.RequestServices.GetRequiredService<ITokenService>();
                    var dbContext = context.RequestServices.GetRequiredService<IApplicationDbContext>();

                    var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);

                    if (principal == null)
                    {
                        Console.WriteLine("Failed to extract claims.");

                        throw new NullReferenceException();
                    }

                    foreach (var claim in principal.Claims) Console.WriteLine($"Claim: {claim.Type} = {claim.Value}");

                    var userIdString = principal.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

                    if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out var userId))
                    {
                        Console.WriteLine("Invalid user ID in token");

                        throw new InvalidOperationException();
                    }

                    var user = await dbContext.Users
                        .Include(u => u.UserRole)
                        .FirstOrDefaultAsync(u => u.Id == userId);

                    if (user == null) throw new NullReferenceException($"User with ID {userId} could not be found.");

                    var newAccessToken = tokenService.GenerateJwtToken(user);
                    var newRefreshToken = tokenService.GenerateRefreshToken();

                    context.Response.Cookies.Append("RefreshToken", newRefreshToken, new CookieOptions
                    {
                        HttpOnly = true,
                        Secure = true,
                        SameSite = SameSiteMode.Strict,
                        Expires = DateTime.UtcNow.AddDays(14)
                    });

                    return Results.Ok(new
                    {
                        AccessToken = newAccessToken,
                        user.FullName,
                        user.Email,
                        UserRole = user.UserRole.Name
                    });
                }
                catch (Exception ex)
                {
                    await Console.Error.WriteLineAsync(ex.Message);
                    return Results.Unauthorized();
                }
            })
            .RequireAuthorization("CustomerPolicy")
            .WithTags("Auth")
            .WithOpenApi();
    }
}
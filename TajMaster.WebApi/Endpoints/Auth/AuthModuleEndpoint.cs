using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Carter;
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
                if (!context.Request.Cookies.ContainsKey("RefreshToken"))
                {
                    return Results.Unauthorized();
                }
                
                var rawHeader = context.Request.Headers["Authorization"];
                Console.WriteLine($"Raw Authorization Header: {rawHeader}");
                var accessToken = rawHeader.ToString().Replace("Bearer ", string.Empty);
                Console.WriteLine($"Parsed Access Token: {accessToken}");
                
                var tokenService = context.RequestServices.GetRequiredService<ITokenService>();
                var unitOfWork = context.RequestServices.GetRequiredService<IUnitOfWork>();
                
                var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);
                if (principal == null)
                {
                    Console.WriteLine("Failed to extract principal from expired token.");
                    return Results.Unauthorized();
                }

              
                var userIdString = principal.FindFirstValue(JwtRegisteredClaimNames.Sub);
                if (!int.TryParse(userIdString, out var userId))
                {
                    return Results.Unauthorized();
                }
                
                var user = await unitOfWork.UserRepository.GetByIdAsync(userId);
                if (user == null)
                {
                    return Results.Unauthorized();
                }
                
                var newAccessToken = tokenService.GenerateJwtToken(user);
                var newRefreshToken = tokenService.GenerateRefreshToken();
                
                context.Response.Cookies.Append("RefreshToken", newRefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(7)
                });
                
                return Results.Ok(new
                {
                    AccessToken = newAccessToken,
                    user.FullName,
                    user.Email,
                    user.Roles
                });
            }
            catch (Exception ex)
            {
                await Console.Error.WriteLineAsync(ex.Message);
                return Results.Unauthorized();
            }
        })
        .WithName("RefreshToken")
        .WithTags("Auth")
        .WithOpenApi();
    }
}

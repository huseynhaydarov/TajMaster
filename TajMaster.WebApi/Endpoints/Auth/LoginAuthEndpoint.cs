using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Auths;
using TajMaster.Application.UseCases.Auths.Commands;

namespace TajMaster.WebApi.Endpoints.Auth;

public class LoginAuthEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/login", async (ISender mediator, HttpContext context,
                [FromBody] LoginCommand command) =>
            {
                var result = await mediator.Send(command);

                if (!result.Success)
                {
                    return Results.Unauthorized();
                }

                context.Response.Cookies.Append("RefreshToken", result.RefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.UtcNow.AddDays(15)
                });

                return Results.Ok(new
                {
                    AccessToken = result.Token,
                    result.FullName,
                    result.Email,
                    result.Role
                });
            })
            .RequireAuthorization().AllowAnonymous()
            .WithName("Login")
            .WithTags("Auth")
            .WithOpenApi();
    }
}
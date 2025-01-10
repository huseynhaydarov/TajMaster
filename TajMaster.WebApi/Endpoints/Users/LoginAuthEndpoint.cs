using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Auth;

namespace TajMaster.WebApi.Endpoints.Users;

public class LoginAuthEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/auth/login", async (ISender mediator, HttpContext context, [FromBody] LoginCommand command) =>
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
                    Expires = DateTime.UtcNow.AddDays(7) 
                });
                
                return Results.Ok(new
                {
                    AccessToken = result.Token,
                    result.FullName,
                    result.Email,
                    result.Roles
                });
            })
            .WithName("Login")
            .WithTags("Auth")
            .WithOpenApi();
    }
}
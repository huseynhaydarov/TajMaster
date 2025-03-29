using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Users.Commands.Create;

namespace TajMaster.WebApi.Endpoints.Users;

public class RegisterUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/user", async ([FromBody] CreateUserCommand command, ISender mediator, 
                CancellationToken cancellationToken) =>
            {
                var user = await mediator.Send(command, cancellationToken);

                return Results.Created($"/api/user/{user}", new { Id = user });
            })
            .RequireAuthorization()
            .AllowAnonymous()
            .WithName("RegisterUserEndpoint")
            .WithTags("Users");
    }
}
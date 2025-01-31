using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Users.Commands.Create;

namespace TajMaster.WebApi.Endpoints.Users;

public class RegisterUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/users", async ([FromBody] CreateUserCommand command, ISender mediator, 
                CancellationToken cancellationToken) =>
            {
                var newUser = await mediator.Send(command, cancellationToken);

                return Results.Created($"/api/users/{newUser}", new { Id = newUser });
            })
            .RequireAuthorization().AllowAnonymous()
            .WithName("RegisterUserEndpoint")
            .WithTags("Users");
    }
}
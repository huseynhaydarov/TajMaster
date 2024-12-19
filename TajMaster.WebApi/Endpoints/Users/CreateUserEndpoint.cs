using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Users.Commands.Create;

namespace TajMaster.WebApi.Endpoints.Users;

public class CreateUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/users", async (ISender mediator, [FromBody] CreateUserCommand command) =>
            {
                var userId = await mediator.Send(command);
                return Results.Created($"/users/{userId}", new { Id = userId });
            })
            .WithName("CreateUserEndpoint");
    }
}
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Users.Commands.Update;

namespace TajMaster.WebApi.Endpoints.Users;

public class UpdateUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/users/{id}", async (ISender mediator, Guid id, [FromBody] UpdateUserCommand command) =>
            {
                if (id != command.UserId) return Results.BadRequest();
                var result = await mediator.Send(command);
                return result ? Results.NoContent() : Results.NotFound();
            })
            .WithName("UpdateUserEndpoint")
            .WithTags("Users");
    }
}
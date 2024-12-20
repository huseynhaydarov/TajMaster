using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Users.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Users;

public class DeleteUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/users/{id}", async (ISender mediator, [FromRoute] int id) =>
            {
                var result = await mediator.Send(new DeleteUserCommand(id));
                return result ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteUserEndpoint");
    }
}
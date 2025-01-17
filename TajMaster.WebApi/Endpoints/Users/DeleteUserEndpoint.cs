using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Users.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Users;

public class DeleteUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/users/{id:guid}", async (ISender mediator, [FromRoute] Guid id) =>
            {
                var result = await mediator.Send(new DeleteUserCommand(id));
                
                return result ? Results.NoContent() : Results.NotFound();
            })
            .WithName("DeleteUserEndpoint")
            .WithTags("Users");
    }
}
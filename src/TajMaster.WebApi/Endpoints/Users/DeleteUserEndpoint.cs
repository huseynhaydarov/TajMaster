using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Users.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Users;

public class DeleteUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/users/{id:guid}", async ([FromRoute] Guid id, ISender mediator, CancellationToken cancellationToken) =>
            {
                await mediator.Send(new DeleteUserCommand(id), cancellationToken);

                return Results.NoContent();
            })
            .RequireAuthorization("AdminOrCustomerPolicy")
            .WithName("DeleteUserEndpoint")
            .WithTags("Users");
    }
}
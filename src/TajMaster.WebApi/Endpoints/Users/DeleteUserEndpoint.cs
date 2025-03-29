using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Users.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Users;

public class DeleteUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/user", async ([FromBody] DeleteUserCommand command, ISender mediator, CancellationToken cancellationToken) =>
            {
                await mediator.Send(command, cancellationToken);

                return Results.NoContent();
            })
            .RequireAuthorization("AdminOrCustomerPolicy")
            .WithName("DeleteUserEndpoint")
            .WithTags("Users");
    }
}
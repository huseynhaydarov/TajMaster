using Carter;
using MediatR;
using TajMaster.Application.UseCases.Users.Commands.Update;

namespace TajMaster.WebApi.Endpoints.Users;

public class UpdateUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/user", async (
                UpdateUserCommand command,
                ISender mediator,
                CancellationToken cancellationToken) =>
            {
                await mediator.Send(command, cancellationToken);
                return Results.NoContent();
            })
            .RequireAuthorization("CustomerPolicy")
            .WithName("UpdateUser")
            .WithTags("Users");
    }
}
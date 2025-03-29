using Carter;
using MediatR;
using TajMaster.Application.Common.Interfaces.IdentityService;
using TajMaster.Application.UseCases.Users.Commands.Update;

namespace TajMaster.WebApi.Endpoints.Users;

public class UpdateUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/user", async (
                UpdateUserCommand command, 
                ISender mediator, 
                IAuthenticatedUserService authenticatedUserService, 
                CancellationToken cancellationToken) =>
            {
                if (authenticatedUserService.UserId != null)
                {
                    var userId = authenticatedUserService.UserId.Value;

                    var updateCommand = command with { UserId = userId };
                    await mediator.Send(updateCommand, cancellationToken);
                }

                return Results.NoContent();
            })
            .RequireAuthorization("AdminOrCustomerPolicy")
            .WithName("UpdateUser")
            .WithTags("Users");

    }
}
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Users.Commands.Update;

namespace TajMaster.WebApi.Endpoints.Users;

public class UpdateUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/users/{id}", async (Guid id, [FromBody] UpdateUserCommand command, 
                ISender mediator) =>
            {
                if (id != command.UserId)
                {
                    return Results.BadRequest();
                }

                await mediator.Send(command);

                return Results.NoContent();
            })
            .RequireAuthorization("AdminOrCustomerPolicy")
            .WithName("UpdateUserEndpoint")
            .WithTags("Users");
    }
}
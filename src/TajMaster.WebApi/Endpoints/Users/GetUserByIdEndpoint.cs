using Carter;
using MediatR;
using TajMaster.Application.UseCases.Users.Queries.GetUser;
using TajMaster.Application.UseCases.Users.UserDtos;

namespace TajMaster.WebApi.Endpoints.Users;

public class GetUserByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/users/{id:guid}", async (Guid id, ISender mediator, CancellationToken cancellationToken) =>
            {
                var user = await mediator.Send(new GetUserByIdQuery(id), cancellationToken);

                return Results.Ok(user);
            })
            .RequireAuthorization("AdminOrCustomerPolicy")
            .WithName("GetUserByIdEndpoint")
            .WithTags("Users")
            .Produces<UserSummaryDto>();
    }
}
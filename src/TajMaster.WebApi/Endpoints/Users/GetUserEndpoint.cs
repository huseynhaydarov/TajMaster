using Carter;
using MediatR;
using TajMaster.Application.UseCases.Users.Queries.GetUser;
using TajMaster.Application.UseCases.Users.UserDtos;

namespace TajMaster.WebApi.Endpoints.Users;

public class GetUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/user", async (ISender mediator, CancellationToken cancellationToken) =>
            {
                var user = await mediator.Send(new GetUserQuery(),cancellationToken);

                return Results.Ok(user);
            })
            .RequireAuthorization("AdminOrCustomerPolicy")
            .WithName("GetUserByIdEndpoint")
            .WithTags("Users")
            .Produces<UserSummaryDto>();
    }
}
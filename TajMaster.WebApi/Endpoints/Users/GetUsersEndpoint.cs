using Carter;
using MediatR;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Users.Queries.GetUsers;
using TajMaster.Application.UseCases.Users.UserDtos;

namespace TajMaster.WebApi.Endpoints.Users;

public class GetUsersEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/users", async ([AsParameters] PagingParameters pagingParameters, ISender mediator) =>
            {
                var results = await mediator.Send(new GetUsersQuery(pagingParameters));

                return Results.Ok(results);
            })
            .RequireAuthorization("AdminOrCustomerPolicy")
            .WithName("GetUsersEndpoint")
            .WithTags("Users")
            .Produces<PaginatedResult<UserDetailDto>>();
    }
}
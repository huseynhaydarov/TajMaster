using Carter;
using MediatR;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.DTO;
using TajMaster.Application.UseCases.Users.Queries;
using TajMaster.Application.UseCases.Users.Queries.GetUsers;

namespace TajMaster.WebApi.Endpoints.Users;

public class GetUsersEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/users", async ([AsParameters] PagingParameters pagingParameters, ISender mediator) =>
            {
                var results = await mediator.Send(new GetUsersQuery(pagingParameters));

                return Results.Ok(results);
            })
            .WithName("GetUsersEndpoint")
            .Produces<PaginatedResult<UserDto>>();
    }
}
using Carter;
using MediatR;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmen;
using TajMaster.Application.UseCases.DTO;
using TajMaster.Application.UseCases.Users.Queries.GetUsers;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class GetCraftsmenEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/craftsmen", async ([AsParameters] PagingParameters pagingParameters, ISender mediator) =>
            {
                var results = await mediator.Send(new GetCraftsmenQuery(pagingParameters));

                return Results.Ok(results);
            })
            .WithName("GetCraftsmenEndpoint")
            .Produces<PaginatedResult<CraftsmanDto>>()
            .WithTags("Craftsmen");
    }
}
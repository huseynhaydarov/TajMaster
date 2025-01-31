using Carter;
using MediatR;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDtos;
using TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmen;

namespace TajMaster.WebApi.Endpoints.Craftsmen;

public class GetCraftsmenEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/craftsmen", async ([AsParameters] PagingParameters pagingParameters, 
                ISender mediator, CancellationToken cancellationToken) =>
            {
                var results = await mediator
                    .Send(new GetCraftsmenQuery(pagingParameters), cancellationToken);

                return Results.Ok(results);
            })
            .RequireAuthorization("AdminPolicy")
            .WithName("GetCraftsmenEndpoint")
            .Produces<PaginatedResult<CraftsmanDto>>()
            .WithTags("Craftsmen");
    }
}
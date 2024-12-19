using Carter;
using MediatR;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.DTO;
using TajMaster.Application.UseCases.Services.Queries;

namespace TajMaster.WebApi.Endpoints.Services;

public class GetServicesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/services", async ([AsParameters] PagingParameters pagingParameters, ISender mediator) =>
            {
                var results = await mediator.Send(new GetServicesQuery(pagingParameters));

                return Results.Ok(results);
            })
            .WithName("GetServicesEndpoint")
            .Produces<PaginatedResult<ServiceDto>>();
    }
}
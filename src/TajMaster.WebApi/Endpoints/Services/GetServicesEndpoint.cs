using Carter;
using MediatR;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Services.Queries.GetServices;
using TajMaster.Application.UseCases.Services.ServiceDtos;

namespace TajMaster.WebApi.Endpoints.Services;

public class GetServicesEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/services", async ([AsParameters] PagingParameters pagingParameters, 
                ISender mediator, CancellationToken cancellationToken) =>
            {
                var results = await mediator
                    .Send(new GetServicesQuery(pagingParameters), cancellationToken);

                return Results.Ok(results);
            })
            .AllowAnonymous()
            .WithName("GetServicesEndpoint")
            .WithTags("Services")
            .Produces<PaginatedResult<ServiceDetailDto>>();
    }
}
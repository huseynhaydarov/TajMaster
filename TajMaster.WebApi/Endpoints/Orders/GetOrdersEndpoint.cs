using Carter;
using MediatR;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Orders.OrderDtos;
using TajMaster.Application.UseCases.Orders.Queries.GetOrders;

namespace TajMaster.WebApi.Endpoints.Orders;

public class GetOrdersEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/orders", async ([AsParameters] PagingParameters pagingParameters, ISender mediator) =>
            {
                var results = await mediator.Send(new GetOrdersQuery(pagingParameters));

                return Results.Ok(results);
            })
            .WithName("GetOrdersEndpoint")
            .WithTags("Orders")
            .Produces<PaginatedResult<OrderSummaryDto>>();
    }
}
using Carter;
using MediatR;
using TajMaster.Application.UseCases.CartStatuses.Queries.GetCartStatusByCode;
using TajMaster.Application.UseCases.OrderStatuses.Queries.GetOrderStatusByCode;
using TajMaster.Application.UseCases.OrderStatuses.Queries.GetOrderStatusByName;

namespace TajMaster.WebApi.Endpoints.OrderStatuses;

public class GetCartStatusByCodeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/order-statuses/code/{code}", async (ISender mediator, string code) =>
            {
                var result = await mediator.Send(new GetOrderStatusByCodeQuery(code));

                return Results.Ok(result);
            })
            .WithName("GetOrderStatusByCodeEndpoint")
            .WithTags("OrderStatuses");
    }
}
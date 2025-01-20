using Carter;
using MediatR;
using TajMaster.Application.UseCases.CartStatuses.Queries.GetCartStatusByName;
using TajMaster.Application.UseCases.OrderStatuses.Queries.GetOrderStatusByName;

namespace TajMaster.WebApi.Endpoints.OrderStatuses;

public class GetCartStatusByNameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/order-statuses/name/{name}", async (ISender mediator, string name) =>
            {
                var result = await mediator.Send(new GetOrderStatusByNameQuery(name));

                return Results.Ok(result);
            })
            .WithName("GetOrderStatusByNameEndpoint")
            .WithTags("CartStatuses");
    }
}
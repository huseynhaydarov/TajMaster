using Carter;
using MediatR;
using TajMaster.Application.UseCases.CartStatuses.Queries.GetCartStatusByName;

namespace TajMaster.WebApi.Endpoints.CartStatuses;

public class GetCartStatusByNameEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/cart-statuses/name/{name}", async (ISender mediator, string name) =>
            {
                var result = await mediator.Send(new GetCartStatusByNameQuery(name));

                return Results.Ok(result);
            })
            .WithName("GetCartStatusByNameEndpoint")
            .WithTags("CartStatuses");
    }
}
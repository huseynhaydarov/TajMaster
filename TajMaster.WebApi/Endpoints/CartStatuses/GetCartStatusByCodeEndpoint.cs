using Carter;
using MediatR;
using TajMaster.Application.UseCases.CartStatuses.Queries.GetCartStatusByCode;

namespace TajMaster.WebApi.Endpoints.CartStatuses;

public class GetCartStatusByCodeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/cart-statuses/code/{code}", async (ISender mediator, string code) =>
            {
                var result = await mediator.Send(new GetCartStatusByCodeQuery(code));

                return Results.Ok(result);
            })
            .WithName("GetCartStatusByCodeEndpoint")
            .WithTags("CartStatuses");
    }
}
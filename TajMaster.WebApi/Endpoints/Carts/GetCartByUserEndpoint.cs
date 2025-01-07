using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Cart.Queries;

namespace TajMaster.WebApi.Endpoints.Carts;

public class GetCartByUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/carts/{userId}", async (ISender mediator, [FromRoute] int userId) =>
            {
                var cart = await mediator.Send(new GetCartByUserIdQuery(userId));
                return Results.Ok(cart);
            })
            .WithName("GetCartEndpoint")
            .WithTags("Carts");
    }
}
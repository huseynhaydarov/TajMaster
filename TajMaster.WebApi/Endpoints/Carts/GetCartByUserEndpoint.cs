using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Cart.Queries;

namespace TajMaster.WebApi.Endpoints.Carts;

public class GetCartByUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/carts/{userId:guid}", async (ISender mediator, [FromRoute] Guid userId, [FromQuery] string? cartStatusName) =>
            {
                // Default to "Active" if cartStatusName is not provided
                cartStatusName ??= "Active";

                var cart = await mediator.Send(new GetCartByUserIdQuery(userId, cartStatusName));
                return Results.Ok(cart);
            })
            .WithName("GetCartEndpoint")
            .WithTags("Carts");
    }
}
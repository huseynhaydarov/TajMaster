using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.CartItems.Commands.Create;

namespace TajMaster.WebApi.Endpoints.Carts;

public class AddCartItemEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/carts/items", async (ISender mediator, [FromBody] AddCartItemCommand command) =>
            {
                var cartItemId = await mediator.Send(command);

                return Results.Created($"/api/carts/items/{cartItemId}", new { Id = cartItemId });
            })
            .RequireAuthorization("CustomerPolicy")
            .WithName("AddCartItemEndpoint")
            .WithTags("Carts");
    }
}
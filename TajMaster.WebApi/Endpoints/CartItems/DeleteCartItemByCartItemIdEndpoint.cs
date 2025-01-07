using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.CartItem.Commands.Delete;
using TajMaster.Application.UseCases.CartItem.Commands.Delete.DeleteByCartItem;

namespace TajMaster.WebApi.Endpoints.CartItems;

public class DeleteCartItemByCartItemIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/cart/items/{cartItemId}", async ([FromRoute] int cartItemId, ISender mediator) =>
            {
                var command = new DeleteCartItemCommand(cartItemId);
                await mediator.Send(command);

                return Results.NoContent();
            })
            .WithName("DeleteCartItemByCartItemIdEndpoint")
            .WithTags("Carts");
    }
}
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.CartItem.Commands.Delete.DeleteByCart;

namespace TajMaster.WebApi.Endpoints.CartItems;

public class DeleteCartItemByCartIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/cart/{cartId:guid}/items", async ([FromRoute] Guid cartId, ISender mediator) =>
            {
                var command = new DeleteCartItemsByCartIdCommand(cartId);
                
                var result = await mediator.Send(command);

                return result
                    ? Results.Ok($"Cart items for cart ID {cartId} have been deleted.")
                    : Results.NotFound($"No cart items found for cart ID {cartId}");
            })
            .WithName("DeleteCartItemByCartIdEndpoint")
            .WithTags("Carts");
    }
}
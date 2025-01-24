using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.CartItems.Commands.Delete.DeleteByCartItem;

namespace TajMaster.WebApi.Endpoints.CartItems;

public class DeleteCartItemByCartItemIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/cart/items/{cartItemId:guid}", async ([FromRoute] Guid cartItemId, ISender mediator) =>
            {
                var command = new DeleteCartItemCommand(cartItemId);

                await mediator.Send(command);

                return Results.NoContent();
            })
            .RequireAuthorization("CustomerPolicy")
            .WithName("DeleteCartItemByCartItemIdEndpoint")
            .WithTags("Carts");
    }
}
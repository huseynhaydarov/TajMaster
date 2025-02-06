using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.CartItems.Commands.Delete.DeleteByCart;

namespace TajMaster.WebApi.Endpoints.CartItems;

public class DeleteCartItemByCartIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/cart/{cartId:guid}/items", async ([FromRoute] Guid cartId, 
                ISender mediator, CancellationToken cancellationToken) =>
            {
                var command = new DeleteCartItemsByCartIdCommand(cartId);
                
                await mediator.Send(command, cancellationToken);

                return Results.NoContent();
            })
            .RequireAuthorization("CustomerPolicy")
            .WithName("DeleteCartItemByCartIdEndpoint")
            .WithTags("Carts");
    }
}
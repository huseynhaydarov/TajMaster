using Carter;
using MediatR;
using TajMaster.Application.UseCases.CartItem.CartItemDTos;
using TajMaster.Application.UseCases.CartItem.Queries.GetCartItemsByCart;

namespace TajMaster.WebApi.Endpoints.CartItems;

public class GetCartItemByCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/cartItems/cart/{cartId}", async (int cartId, ISender sender) =>
            {
                if (cartId <= 0)
                    return Results.BadRequest(new { Message = "CartId must be a positive integer." });

                var query = new GetCartItemsByCartIdQuery(cartId);

                var carts = await sender.Send(query);

                var cartItemDto = carts as CartItemDto[] ?? carts.ToArray();
                if (!cartItemDto.Any())
                    return Results.NotFound(new { Message = $"No cartItems found for cart ID {cartId}." });

                return Results.Ok(cartItemDto);
            })
            .WithName("GetCartItemsByCartEndpoint")
            .WithTags("CartItems")
            .Produces<IEnumerable<CartItemDto>>();
    }
}
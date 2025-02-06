using Carter;
using MediatR;
using TajMaster.Application.UseCases.CartItems.CartItemDtos;
using TajMaster.Application.UseCases.CartItems.Queries.GetCartItemsByCart;

namespace TajMaster.WebApi.Endpoints.CartItems;

public class GetCartItemByCartEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/cartItems/cart/{cartId:guid}", async (Guid cartId, ISender sender, 
                CancellationToken cancellationToken) =>
            {
                if (cartId == Guid.Empty)
                {
                    return Results.BadRequest();
                }

                var query = new GetCartItemsByCartIdQuery(cartId);

                var carts = await sender.Send(query, cancellationToken);

                var cartItemDto = carts as CartItemDto[] ?? carts.ToArray();

                if (!cartItemDto.Any())
                {
                    return Results.NotFound();
                }

                return Results.Ok(cartItemDto);
            })
            .RequireAuthorization("CustomerPolicy")
            .WithName("GetCartItemsByCartEndpoint")
            .WithTags("CartItems")
            .Produces<IEnumerable<CartItemDto>>();
    }
}
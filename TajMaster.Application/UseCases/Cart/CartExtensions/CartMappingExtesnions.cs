using TajMaster.Application.UseCases.Cart.CartDtos;
using TajMaster.Application.UseCases.CartItem.CartItemDTos;
using TajMaster.Application.UseCases.CartItem.CartItemExtensions;

namespace TajMaster.Application.UseCases.Cart.CartExtensions;

public static class CartMappingExtensions
{
    public static CartDto ToCartDto(this Domain.Entities.Cart cart)
    {
        return new CartDto(
            cart.Id,
            cart.UserId,
            cart.CartStatus.ToString(),
            cart.Subtotal,
            cart.CartItems?.Select(ci => ci.ToCartItemDto()).ToList() ?? new List<CartItemDto>()
        );
    }

    public static List<CartDto> ToCartDtoList(this IEnumerable<Domain.Entities.Cart> carts)
    {
        return carts.Select(cart => cart.ToCartDto()).ToList();
    }
}
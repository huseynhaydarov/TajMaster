using TajMaster.Application.UseCases.CartItem.CartItemDTos;
using TajMaster.Application.UseCases.CartItems.CartItemExtensions;
using TajMaster.Application.UseCases.Carts.CartDtos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Carts.CartExtensions;

public static class CartMappingExtensions
{
    public static CartDto ToCartDto(this Cart cart)
    {
        return new CartDto(
            cart.Id,
            cart.UserId,
            cart.CartStatus.Name,
            cart.Subtotal,
            cart.CartItems?.Select(ci => ci.ToCartItemDto()).ToList() ?? new List<CartItemDto>()
        );
    }

    public static List<CartDto> ToCartDtoList(this IEnumerable<Cart> carts)
    {
        return carts.Select(cart => cart.ToCartDto()).ToList();
    }
}
using TajMaster.Application.UseCases.CartItems.CartItemDTos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.CartItems.CartItemExtensions;

public static class CartItemMappingExtensions
{
    public static CartItemDto ToCartItemDto(this CartItem cartItem)
    {
        return new CartItemDto(
            cartItem.Id,
            ServiceId: cartItem.ServiceId,
            ServiceName: cartItem.Service?.Title ?? string.Empty,
            Price: cartItem.Price
        );
    }

    public static List<CartItemDto> ToCartItemDtoList(this IEnumerable<CartItem> cartItems)
    {
        return cartItems.Select(cartItem => cartItem.ToCartItemDto()).ToList();
    }
}
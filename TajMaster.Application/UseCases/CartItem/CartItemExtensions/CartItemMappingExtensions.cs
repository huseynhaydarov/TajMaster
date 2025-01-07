using TajMaster.Application.UseCases.CartItem.CartItemDTos;

namespace TajMaster.Application.UseCases.CartItem.CartItemExtensions;


public static class CartItemMappingExtensions
{
    public static CartItemDto ToCartItemDto(this Domain.Entities.CartItem cartItem)
    {
        return new CartItemDto(
            CartItemId: cartItem.Id,
            ServiceId: cartItem.ServiceId,
            ServiceName: cartItem.Service?.Title ?? string.Empty,
            Price: cartItem.Price
        );
    }

    public static List<CartItemDto> ToCartItemDtoList(this IEnumerable<Domain.Entities.CartItem> cartItems)
    {
        return cartItems.Select(cartItem => cartItem.ToCartItemDto()).ToList();
    }
}

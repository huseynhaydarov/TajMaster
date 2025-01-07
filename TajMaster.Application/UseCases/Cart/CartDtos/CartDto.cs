using TajMaster.Application.UseCases.CartItem.CartItemDTos;

namespace TajMaster.Application.UseCases.Cart.CartDtos;

public record CartDto(
    int CartId,
    int UserId,
    string CartStatus,
    decimal SubTotal,
    List<CartItemDto> CartItems);
using TajMaster.Application.UseCases.CartItem.CartItemDTos;

namespace TajMaster.Application.UseCases.Cart.CartDtos;

public record CartDto(
    Guid CartId,
    Guid UserId,
    string CartStatusName,
    decimal SubTotal,
    List<CartItemDto> CartItems);
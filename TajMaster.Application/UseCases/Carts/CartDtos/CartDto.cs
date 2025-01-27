using TajMaster.Application.UseCases.CartItems.CartItemDtos;

namespace TajMaster.Application.UseCases.Carts.CartDtos;

public record CartDto(
    Guid CartId,
    Guid UserId,
    string CartStatus,
    decimal SubTotal,
    List<CartItemDto> CartItems);
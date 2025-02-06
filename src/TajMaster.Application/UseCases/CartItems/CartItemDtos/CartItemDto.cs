namespace TajMaster.Application.UseCases.CartItems.CartItemDtos;

public record CartItemDto(
    Guid CartItemId,
    string ServiceName,
    Guid ServiceId,
    decimal Price
);
namespace TajMaster.Application.UseCases.CartItems.CartItemDTos;

public record CartItemDto(
    Guid CartItemId,
    string ServiceName,
    Guid ServiceId,
    decimal Price
);
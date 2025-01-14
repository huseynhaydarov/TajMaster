namespace TajMaster.Application.UseCases.CartItem.CartItemDTos;

public record CartItemDto(
    Guid CartItemId,
    string ServiceName,
    Guid ServiceId,
    decimal Price
);
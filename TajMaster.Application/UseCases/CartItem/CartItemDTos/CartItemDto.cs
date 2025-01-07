namespace TajMaster.Application.UseCases.CartItem.CartItemDTos;

public record CartItemDto(
    int CartItemId,
    string ServiceName,
    int ServiceId,
    decimal Price
);
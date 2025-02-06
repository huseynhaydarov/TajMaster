namespace TajMaster.Application.UseCases.OrderItems;

public record OrderItemDto(
    Guid OrderId,
    Guid ServiceId,
    int Quantity,
    decimal Price);
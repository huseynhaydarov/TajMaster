namespace TajMaster.Application.UseCases.OrderItems;

public record OrderItemDto(
    int OrderId,
    int ServiceId,
    int Quantity,
    decimal Price);
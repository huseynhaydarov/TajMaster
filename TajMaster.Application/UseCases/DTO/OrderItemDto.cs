namespace TajMaster.Application.UseCases.DTO;

public record OrderItemDto(
    int OrderId,
    int ServiceId,
    int Quantity,
    decimal Price);
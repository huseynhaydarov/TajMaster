namespace TajMaster.Application.UseCases.DTO;

public record CartItemDto(
    int CartId,
    string ServiceName,
    int ServiceId,
    int Quantity,
    decimal Price,
    decimal Total
);
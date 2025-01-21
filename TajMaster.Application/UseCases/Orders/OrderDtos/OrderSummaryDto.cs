namespace TajMaster.Application.UseCases.Orders.OrderDtos;

public record OrderSummaryDto(
    Guid OrderId,
    Guid UserId,
    DateTime AppointmentDate,
    string Address,
    string OrderStatus,
    decimal TotalPrice);
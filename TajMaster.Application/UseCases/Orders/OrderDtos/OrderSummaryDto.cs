namespace TajMaster.Application.UseCases.Orders.OrderDtos;

public record OrderSummaryDto(
    int OrderId,
    int UserId,
    int CraftsmanId,
    DateTime AppointmentDate,
    string Address,
    string OrderStatus,
    decimal TotalPrice);
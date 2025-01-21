using TajMaster.Application.UseCases.OrderItems;

namespace TajMaster.Application.UseCases.Orders.OrderDtos;

public record OrderDetailDto(
    Guid OrderId,
    Guid UserId,
    DateTime AppointmentDate,
    string Address,
    string OrderStatus,
    decimal TotalPrice,
    List<OrderItemDto> OrderItems);
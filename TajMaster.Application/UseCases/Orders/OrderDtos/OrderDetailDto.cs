using TajMaster.Application.UseCases.OrderItems;

namespace TajMaster.Application.UseCases.Orders.OrderDtos;

public record OrderDetailDto(
    int OrderId,
    int UserId,
    int CraftsmanId,
    DateTime AppointmentDate,
    string Address,
    string OrderStatus,
    decimal TotalPrice,
    List<OrderItemDto> OrderItems);
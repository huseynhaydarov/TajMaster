using TajMaster.Domain.Entities;
using TajMaster.Domain.Enums;

namespace TajMaster.Application.UseCases.DTO;

public record OrderDto(
    int OrderId,
    int UserId,
    int CraftsmanId,
    DateTime AppointmentDate,
    string Address,
    string OrderStatus,
    decimal TotalPrice,
    List<ReviewDto> Reviews,
    List<OrderItemDto> OrderItems);
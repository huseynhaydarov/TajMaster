using TajMaster.Application.UseCases.DTO;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Orders.Create;

public record CreateOrderCommand(
    int UserId,
    int CraftsmanId,
    DateTime AppointmentDate,
    string Address,
    decimal TotalPrice,
    List<OrderItemDto> OrderItems) 
    : ICommand<int>;

using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Orders.Create;

public record CreateOrderCommand(
    int UserId,
    int CraftsmanId,
    DateTime AppointmentDate,
    string Address)
    : ICommand<int>;
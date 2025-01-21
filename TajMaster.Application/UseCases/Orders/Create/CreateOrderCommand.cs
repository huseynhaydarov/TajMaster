using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Orders.Create;

public record CreateOrderCommand(
    Guid UserId,
    DateTime AppointmentDate,
    string Address)
    : ICommand<Guid>;
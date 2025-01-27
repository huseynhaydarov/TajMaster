using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Orders.Commands.Update;

public record UpdateOrderStatusCommand(Guid OrderId, Guid OrderStatusId) : ICommand<Unit>;

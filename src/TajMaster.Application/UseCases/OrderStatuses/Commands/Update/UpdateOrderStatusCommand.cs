using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.OrderStatuses.Commands.Update;

public record UpdateOrderStatusCommand(Guid OrderStatusId, string Name, int Code) : ICommand<Unit>;
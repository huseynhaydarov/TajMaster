using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.OrderStatuses.Commands.Delete;

public record DeleteOrderStatusCommand(Guid Id) : ICommand<Unit>;
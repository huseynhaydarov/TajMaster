using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.OrderStatuses.Commands.Create;

public record CreateOrderStatusCommand(string Name, string Code) : ICommand<Guid>;
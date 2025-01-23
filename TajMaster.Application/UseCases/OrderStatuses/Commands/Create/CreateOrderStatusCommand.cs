using MediatR;

namespace TajMaster.Application.UseCases.OrderStatuses.Commands.Create;

public record CreateOrderStatusCommand(string Name, string Code) : IRequest<Guid>;
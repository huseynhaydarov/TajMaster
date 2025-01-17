using MediatR;

namespace TajMaster.Application.UseCases.OrderStatuses.Commands.Delete;

public record DeleteOrderStatusCommand(Guid Id) : IRequest<bool>;
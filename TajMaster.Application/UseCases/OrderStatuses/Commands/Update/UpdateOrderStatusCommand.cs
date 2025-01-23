using MediatR;

namespace TajMaster.Application.UseCases.OrderStatuses.Commands.Update;

public record UpdateOrderStatusCommand(Guid OrderStatusId, string Name, int Code) : IRequest<bool>;
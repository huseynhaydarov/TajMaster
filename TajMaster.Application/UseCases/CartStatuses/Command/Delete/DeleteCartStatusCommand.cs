using MediatR;

namespace TajMaster.Application.UseCases.CartStatuses.Command.Delete;

public record DeleteCartStatusCommand(Guid Id) : IRequest<bool>;
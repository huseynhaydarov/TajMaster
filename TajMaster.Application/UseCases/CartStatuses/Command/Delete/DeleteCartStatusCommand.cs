using MediatR;

namespace TajMaster.Application.UseCases.CartStatus.Command.Delete;

public record DeleteCartStatusCommand(Guid Id) : IRequest<bool>;
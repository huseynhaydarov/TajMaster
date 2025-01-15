using MediatR;

namespace TajMaster.Application.UseCases.CartStatus.Command.Update;

public record UpdateCartStatusCommand(Guid CartStatusId, string Name, int Code) : IRequest<bool>;
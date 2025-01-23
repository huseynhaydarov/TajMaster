using MediatR;

namespace TajMaster.Application.UseCases.CartStatuses.Command.Create;

public record CreateCartStatusCommand(string Name, string Code) : IRequest<Guid>;
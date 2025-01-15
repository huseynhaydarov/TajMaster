using MediatR;

namespace TajMaster.Application.UseCases.CartStatuses.Command.Create;

public record CreateCartStatusCommand(string Name, int Code) : IRequest<Guid>;
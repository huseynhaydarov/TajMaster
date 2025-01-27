using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.CartStatuses.Command.Create;

public record CreateCartStatusCommand(string Name, string Code) : ICommand<Guid>;
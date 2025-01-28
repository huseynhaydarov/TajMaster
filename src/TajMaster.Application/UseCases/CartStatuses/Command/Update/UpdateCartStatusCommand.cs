using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.CartStatuses.Command.Update;

public record UpdateCartStatusCommand(Guid CartStatusId, string Name, int Code) : ICommand<Unit>;
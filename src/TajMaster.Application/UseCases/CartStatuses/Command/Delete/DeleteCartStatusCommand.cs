using System.Windows.Input;
using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.CartStatuses.Command.Delete;

public record DeleteCartStatusCommand(Guid Id) : ICommand<Unit>; 
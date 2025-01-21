using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Carts.Commands;

public record CreateCartCommand(Guid UserId) : ICommand<Guid>;
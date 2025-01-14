using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Cart.Commands;

public record CreateCartCommand(Guid UserId) : ICommand<Guid>;
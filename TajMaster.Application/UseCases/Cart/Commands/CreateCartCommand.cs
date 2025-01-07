using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Cart.Commands;

public record CreateCartCommand(int UserId) : ICommand<int>;
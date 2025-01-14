using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Create.CreateCraftsman;

public record CreateCraftsmanCommand(
    string FullName,
    string? Email,
    string Password,
    string? Address,
    string Phone)
    : ICommand<Guid>;
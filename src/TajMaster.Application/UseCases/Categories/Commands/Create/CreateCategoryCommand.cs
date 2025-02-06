using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Categories.Commands.Create;

public record CreateCategoryCommand(
    string Name,
    string Description)
    : ICommand<Guid>;
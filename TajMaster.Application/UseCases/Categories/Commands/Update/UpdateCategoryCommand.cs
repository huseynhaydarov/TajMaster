using MediatR;

namespace TajMaster.Application.UseCases.Categories.Commands.Update;

public record UpdateCategoryCommand(
    Guid CategoryId,
    string Name,
    string Description) : IRequest<bool>;
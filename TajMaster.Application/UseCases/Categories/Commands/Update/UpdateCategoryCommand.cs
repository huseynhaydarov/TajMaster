using MediatR;

namespace TajMaster.Application.UseCases.Categories.Commands.Update;

public record UpdateCategoryCommand(
    int CategoryId,
    string Name,
    string Description) : IRequest<bool>;

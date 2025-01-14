using MediatR;

namespace TajMaster.Application.UseCases.Categories.Commands.Delete;

public record DeleteCategoryCommand(Guid CategoryId) : IRequest<bool>;
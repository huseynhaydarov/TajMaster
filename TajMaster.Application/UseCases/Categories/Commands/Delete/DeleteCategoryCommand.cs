using MediatR;

namespace TajMaster.Application.UseCases.Categories.Commands.Delete;

public record DeleteCategoryCommand(int CategoryId) : IRequest<bool>;
using System.Windows.Input;
using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Categories.Commands.Update;

public record UpdateCategoryCommand(
    Guid CategoryId,
    string? Name,
    string? Description) : ICommand<Unit>;
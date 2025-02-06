using System.Windows.Input;
using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Categories.Commands.Delete;

public record DeleteCategoryCommand(Guid CategoryId) : ICommand<Unit>;
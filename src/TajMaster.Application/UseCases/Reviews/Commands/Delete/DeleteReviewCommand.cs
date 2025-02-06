using System.Windows.Input;
using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Reviews.Commands.Delete;

public record DeleteReviewCommand(Guid ReviewId) : ICommand<Unit>;
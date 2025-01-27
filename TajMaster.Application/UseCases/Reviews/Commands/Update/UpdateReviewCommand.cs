using System.Windows.Input;
using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Reviews.Commands.Update;

public record UpdateReviewCommand(
    Guid ReviewId,
    int Rating,
    string Comment) : ICommand<Unit>;
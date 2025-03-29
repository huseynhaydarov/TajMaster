using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Reviews.Commands.Create;

public record CreateReviewCommand(
    Guid OrderId,
    Guid CraftsmanId,
    int Rating,
    string Comment,
    DateTime ReviewDate)
    : ICommand<Guid>;
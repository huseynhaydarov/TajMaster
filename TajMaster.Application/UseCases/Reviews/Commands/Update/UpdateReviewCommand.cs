using MediatR;

namespace TajMaster.Application.UseCases.Reviews.Commands.Update;

public record UpdateReviewCommand(
    Guid ReviewId,
    int Rating,
    string Comment)
    : IRequest<bool>;
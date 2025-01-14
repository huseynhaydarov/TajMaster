using MediatR;

namespace TajMaster.Application.UseCases.Reviews.Commands.Delete;

public record DeleteReviewCommand(Guid ReviewId) : IRequest<bool>;
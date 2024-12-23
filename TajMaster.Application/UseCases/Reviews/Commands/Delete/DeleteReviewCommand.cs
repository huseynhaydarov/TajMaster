using MediatR;

namespace TajMaster.Application.UseCases.Reviews.Commands.Delete;

public record DeleteReviewCommand(int ReviewId) : IRequest<bool>;
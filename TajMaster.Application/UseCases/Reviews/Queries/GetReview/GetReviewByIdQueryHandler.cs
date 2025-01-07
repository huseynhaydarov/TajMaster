using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;
using TajMaster.Application.UseCases.Reviews.ReviewExtensions;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReview;

public class GetReviewByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetReviewByIdQuery, ReviewDto>
{
    public async Task<ReviewDto> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
    {
        var review = await unitOfWork.ReviewRepository.GetByIdAsync(request.ReviewId, cancellationToken);

        if (review == null)
            throw new NotFoundException($"Review with ID {request.ReviewId} not found.");

        return review.ToReviewDto();
    }
}
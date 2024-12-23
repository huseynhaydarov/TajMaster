using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Users.Exceptions;
using TajMaster.Application.UseCases.Users.Queries.GetUser;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReview;

public class GetReviewByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetReviewByIdQuery, Review>
{
    public async Task<Review> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
    {
        var review = await unitOfWork.ReviewRepository.GetByIdAsync(request.ReviewId, cancellationToken);

        if (review == null)
            throw new NotFoundException($"Review with ID {request.ReviewId} not found.");
        
        return review;
    }
}
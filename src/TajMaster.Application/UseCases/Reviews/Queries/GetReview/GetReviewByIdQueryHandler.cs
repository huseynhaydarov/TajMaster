using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;
using TajMaster.Application.UseCases.Reviews.ReviewExtensions;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReview;

public class GetReviewByIdQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetReviewByIdQuery, ReviewDto>
{
    public async Task<ReviewDto> Handle(GetReviewByIdQuery query, CancellationToken cancellationToken)
    {
        var review = await context.Reviews
            .FirstOrDefaultAsync(r => r.Id == query.ReviewId, cancellationToken);

        if (review == null)
        {
            throw new NotFoundException($"Review with ID {query.ReviewId} not found.");
        }

        return review.ToReviewDto();
    }
}
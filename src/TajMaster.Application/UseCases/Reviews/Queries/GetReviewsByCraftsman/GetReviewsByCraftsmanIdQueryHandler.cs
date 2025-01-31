using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;
using TajMaster.Application.UseCases.Reviews.ReviewExtensions;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReviewsByCraftsman;

public class GetReviewsByCraftsmanIdQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetReviewsByCraftsmanIdQuery, IEnumerable<ReviewDto>>
{
    public async Task<IEnumerable<ReviewDto>> Handle(GetReviewsByCraftsmanIdQuery request,
        CancellationToken cancellationToken)
    {
        var reviews = await context.Reviews
            .AsNoTracking()
            .Include(r => r.Craftsman)
            .Where(r => r.CraftsmanId == request.CraftsmanId)
            .ToListAsync(cancellationToken);

        if (!reviews.Any())
        {
            throw new NotFoundException($"No reviews found for craftsman with ID: {request.CraftsmanId}");
        }

        return reviews.ToReviewDtoList();
    }
}
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;
using TajMaster.Application.UseCases.Reviews.ReviewExtensions;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReviews;

public class GetReviewsQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetReviewsQuery, PaginatedResult<ReviewDto>>
{
    public async Task<PaginatedResult<ReviewDto>> Handle(GetReviewsQuery query, CancellationToken cancellationToken)
    {
        var pagingParams = query.PagingParameters;

        var request = context.Reviews
            .AsNoTracking()
            .AsQueryable();

        request = pagingParams.OrderByDescending == true
            ? request.OrderByDescending(s => s.Id)
            : request.OrderBy(u => u.Id);

        var totalCount = await request.CountAsync(cancellationToken);

        var reviewDto = request.ToReviewDtoList();

        var paginatedResult = new PaginatedResult<ReviewDto>(
            (int)pagingParams.PageNumber!,
            (int)pagingParams.PageSize!,
            totalCount,
            reviewDto
        );

        return paginatedResult;
    }
}
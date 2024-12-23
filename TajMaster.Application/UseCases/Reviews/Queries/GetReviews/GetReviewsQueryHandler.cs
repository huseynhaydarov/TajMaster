using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.DTO;
using TajMaster.Application.UseCases.Users.Queries.GetUsers;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReviews;

public class GetReviewsQueryHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetReviewsQuery, PaginatedResult<ReviewDto>>
{
    public async Task<PaginatedResult<ReviewDto>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
    {
        var pagingParams = request.PagingParameters;

        var paginatedReviews = await unitOfWork.ReviewRepository.GetAllAsync(pagingParams, cancellationToken);

        var totalCount = paginatedReviews.Count();

        var reviewDto = paginatedReviews
            .Select(review => new ReviewDto(
                review.Id,
                review.OrderId,
                review.UserId,
                review.CraftsmanId,
                review.Rating,
                review.Comment,
                review.ReviewDate
            ))
            .ToList();

        var paginatedResult = new PaginatedResult<ReviewDto>(
            (int)pagingParams.PageNumber!,
            (int)pagingParams.PageSize!,
            totalCount,
            reviewDto
        );

        return paginatedResult;
    }
}
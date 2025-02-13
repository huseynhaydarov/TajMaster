using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReviews;

public record GetReviewsQuery(PagingParameters PagingParameters) : IQuery<PaginatedResult<ReviewDto>>;
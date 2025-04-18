using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReview;

public record GetReviewByIdQuery(Guid ReviewId) : IQuery<ReviewDto>;
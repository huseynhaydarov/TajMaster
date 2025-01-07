using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReview;

public record GetReviewByIdQuery(int ReviewId) : IQuery<ReviewDto>;
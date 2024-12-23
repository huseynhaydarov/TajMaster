using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReview;

public record GetReviewByIdQuery(int ReviewId) : IQuery<Review>;
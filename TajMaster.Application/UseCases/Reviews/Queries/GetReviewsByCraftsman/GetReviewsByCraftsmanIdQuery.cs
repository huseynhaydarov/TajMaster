using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReviewsByCraftsman;

public record GetReviewsByCraftsmanIdQuery(int CraftsmanId) : IQuery<IEnumerable<ReviewDto>>;
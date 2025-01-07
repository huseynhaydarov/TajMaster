using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReviewsByUser;

public record GetReviewsByCustomerIdQuery(int UserId) : IQuery<IEnumerable<ReviewDto>>;

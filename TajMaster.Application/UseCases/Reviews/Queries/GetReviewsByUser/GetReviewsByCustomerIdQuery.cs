using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.DTO;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReviewsByUser;

public record GetReviewsByCustomerIdQuery(int UserId) : IQuery<IEnumerable<ReviewDto>>;

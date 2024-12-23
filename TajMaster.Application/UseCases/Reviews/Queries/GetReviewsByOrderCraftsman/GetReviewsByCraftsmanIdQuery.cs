using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.DTO;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReviewsByOrderCraftsman;

public record GetReviewsByCraftsmanIdQuery(int CraftsmanId) : IQuery<IEnumerable<ReviewDto>>;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;
using TajMaster.Application.UseCases.Reviews.ReviewExtensions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReviewsByCraftsman;

public class GetReviewsByCraftsmanIdQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetReviewsByCraftsmanIdQuery, IEnumerable<ReviewDto>>
{
    public async Task<IEnumerable<ReviewDto>> Handle(GetReviewsByCraftsmanIdQuery request,
        CancellationToken cancellationToken)
    {
        var reviews =
            await unitOfWork.ReviewRepository.GetReviewsByCraftsmanIdAsNoTracking(request.CraftsmanId,
                cancellationToken);

        var enumerable = reviews as Review[] ?? reviews.ToArray();
        if (reviews == null || !enumerable.Any())
            throw new NotFoundException($"No reviews found for craftsman with ID: {request.CraftsmanId}");

        return enumerable.ToReviewDtoList();
    }
}
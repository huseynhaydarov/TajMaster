using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;
using TajMaster.Application.UseCases.Reviews.ReviewExtensions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReviewsByUser;

public class GetReviewsByUserQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetReviewsByCustomerIdQuery, IEnumerable<ReviewDto>>
{
    public async Task<IEnumerable<ReviewDto>> Handle(GetReviewsByCustomerIdQuery request,
        CancellationToken cancellationToken)
    {
        var reviews =
            await unitOfWork.ReviewRepository.GetReviewsByUserIdAsNoTrackingAsync(request.UserId, cancellationToken);

        var enumerable = reviews as Review[] ?? reviews.ToArray();
        if (reviews == null || !enumerable.Any())
            throw new NotFoundException($"No reviews found for user with ID: {request.UserId}");

        return enumerable.ToReviewDtoList();
    }
}
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.IdentityService;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Reviews.ReviewDtos;
using TajMaster.Application.UseCases.Reviews.ReviewExtensions;

namespace TajMaster.Application.UseCases.Reviews.Queries.GetReviewsByUser;

public class GetReviewsByUserQueryHandler(
    IApplicationDbContext context,
    IAuthenticatedUserService  authenticatedUserService)
    : IQueryHandler<GetReviewsByCustomerQuery, IEnumerable<ReviewDto>>
{
    public async Task<IEnumerable<ReviewDto>> Handle(GetReviewsByCustomerQuery request,
        CancellationToken cancellationToken)
    {
        var reviews = await context.Reviews
            .AsQueryable()
            .Include(r => r.User)
            .Where(r => r.UserId == authenticatedUserService.UserId)
            .ToListAsync(cancellationToken);

        if (!reviews.Any())
        {
            throw new NotFoundException($"No reviews found for user with ID: {authenticatedUserService.UserId}");
        }

        return reviews.ToReviewDtoList();
    }
}
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Domain.Entities;
using TajMaster.Infrastructure.Persistence.Data;

namespace TajMaster.Infrastructure.Persistence.Repositories;

public class ReviewRepository(ApplicationDbContext context) : Repository<Review>(context), IReviewRepository
{
    public async Task<IEnumerable<Review>> GetReviewsByUserIdAsNoTrackingAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await context.Reviews
            .AsNoTracking()
            .Include(review => review.User)
            .Where(review => review.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Review>> GetReviewsByCraftsmanIdAsNoTracking(int craftsmanId, CancellationToken cancellationToken = default)
    {
        return await context.Reviews
            .AsNoTracking()
            .Include(review => review.Craftsman)
            .Where(review => review.CraftsmanId == craftsmanId)
            .ToListAsync(cancellationToken);
    }
}
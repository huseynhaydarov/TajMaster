using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Application.Common.Pagination;
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
    
    public override async Task<List<Review>> GetAllAsync(PagingParameters pagingParameters, CancellationToken cancellationToken = default)
    {
        var query = context.Reviews
            .AsQueryable();

        if(pagingParameters.OrderByDescending == true)
        {
            query = query.OrderByDescending(o => o.Id);
        }
        else
        {
            query = query.OrderBy(o => o.Id);
        }
        return await query
            .Skip(pagingParameters.Skip)
            .Take(pagingParameters.Take)
            .ToListAsync(cancellationToken);
    }
}
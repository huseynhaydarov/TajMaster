using TajMaster.Domain.Entities;

namespace TajMaster.Application.Common.Interfaces.Repositories;

public interface IReviewRepository : IRepository<Review>
{
    Task<IEnumerable<Review>> GetReviewsByUserIdAsNoTrackingAsync(int userId,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<Review>> GetReviewsByCraftsmanIdAsNoTracking(int craftsmanId,
        CancellationToken cancellationToken = default);
}
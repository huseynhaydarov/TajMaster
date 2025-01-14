using TajMaster.Domain.Entities;

namespace TajMaster.Application.Common.Interfaces.Repositories;

public interface IReviewRepository : IRepository<Review>
{
    Task<IEnumerable<Review>> GetReviewsByUserIdAsNoTrackingAsync(Guid userId,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<Review>> GetReviewsByCraftsmanIdAsNoTracking(Guid craftsmanId,
        CancellationToken cancellationToken = default);
}
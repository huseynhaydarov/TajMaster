using TajMaster.Domain.Entities;

namespace TajMaster.Application.Common.Interfaces.Repositories;

public interface IServiceRepository : IRepository<Service>
{
    Task<IEnumerable<Service>> GetServicesByCategoryIdAsNoTrackingAsync(int categoryId,
        CancellationToken cancellationToken = default);
}
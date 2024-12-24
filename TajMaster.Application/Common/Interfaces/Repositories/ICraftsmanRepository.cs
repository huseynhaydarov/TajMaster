using TajMaster.Domain.Entities;

namespace TajMaster.Application.Common.Interfaces.Repositories;

public interface ICraftsmanRepository : IRepository<Craftsman>
{
    Task<IEnumerable<Craftsman>> GetCraftsmanByUserIdAsNoTrackingAsync(int userId,
        CancellationToken cancellationToken = default);

    Task<List<Craftsman>> GetBySpecializationAsync(string specialization, CancellationToken cancellationToken = default);

    IQueryable<Craftsman> GetAll();
}
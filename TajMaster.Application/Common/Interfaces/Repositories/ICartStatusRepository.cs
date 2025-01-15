using TajMaster.Domain.Entities;

namespace TajMaster.Application.Common.Interfaces.Repositories;

public interface ICartStatusRepository : IRepository<CartStatusEntity>
{
    Task<CartStatusEntity> GetByNameAsync(string name, CancellationToken cancellationToken);
    Task<CartStatusEntity> GetByCodeAsync(string code, CancellationToken cancellationToken);
}

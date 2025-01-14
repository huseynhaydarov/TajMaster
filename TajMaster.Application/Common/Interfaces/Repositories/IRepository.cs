using TajMaster.Application.Common.Pagination;

namespace TajMaster.Application.Common.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    Task<List<T>> GetAllAsync(PagingParameters pagingParameters, CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IList<T>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
}
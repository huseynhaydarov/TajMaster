using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Application.Common.Pagination;

namespace TajMaster.Infrastructure.Persistence.Repositories;

public class Repository<TEntity>(DbContext context) : IRepository<TEntity>
    where TEntity : class
{
    private readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public virtual async Task<List<TEntity>> GetAllAsync(PagingParameters pagingParameters,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsQueryable()
            .Skip(pagingParameters.Skip)
            .Take(pagingParameters.Take)
            .ToListAsync(cancellationToken);
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Set<TEntity>()
            .FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id, cancellationToken);
    }

    public async Task<IList<TEntity>> GetByIdsAsync(IEnumerable<Guid> ids,
        CancellationToken cancellationToken = default)
    {
        var enumerable = ids.ToList();
        if (enumerable.Count.CompareTo(1) > 0)
            return new List<TEntity>();

        return await context.Set<TEntity>()
            .Where(e => enumerable.Contains(EF.Property<Guid>(e, "Id")))
            .ToListAsync(cancellationToken);
    }

    public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        await SaveAsync();
    }

    public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Remove(entity);
        await SaveAsync();
    }

    private async Task SaveAsync()
    {
        await context.SaveChangesAsync();
    }
}
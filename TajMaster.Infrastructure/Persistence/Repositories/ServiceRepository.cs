using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Application.Common.Pagination;
using TajMaster.Domain.Entities;
using TajMaster.Infrastructure.Persistence.Data;

namespace TajMaster.Infrastructure.Persistence.Repositories;

public class ServiceRepository(ApplicationDbContext context) : Repository<Service>(context), IServiceRepository
{
    public async Task<IEnumerable<Service>> GetServicesByCategoryIdAsNoTrackingAsync(int categoryId,
        CancellationToken cancellationToken = default)
    {
        return await context.Services
            .AsNoTracking()
            .Include(service => service.Categories)
            .Where(service => service.Categories.Any(category => category.Id == categoryId))
            .ToListAsync(cancellationToken);
    }

    public override async Task<Service?> GetByIdAsync(int serviceId, CancellationToken cancellationToken = default)
    {
        var service = await context.Services
            .Include(s => s.Categories) // Ensuring categories are loaded
            .FirstOrDefaultAsync(s => s.Id == serviceId, cancellationToken);

        return service;
    }

    public override async Task<List<Service>> GetAllAsync(PagingParameters pagingParameters,
        CancellationToken cancellationToken = default)
    {
        var query = context.Services
            .Include(u => u.Categories)
            .AsQueryable();

        if (pagingParameters.OrderByDescending == true)
            query = query.OrderByDescending(o => o.Id);
        else
            query = query.OrderBy(o => o.Id);
        return await query
            .Skip(pagingParameters.Skip)
            .Take(pagingParameters.Take)
            .ToListAsync(cancellationToken);
    }
}
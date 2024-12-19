using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Repositories;
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
}
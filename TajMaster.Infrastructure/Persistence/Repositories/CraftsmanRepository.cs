using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Application.Common.Pagination;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;
using TajMaster.Domain.Enums;
using TajMaster.Infrastructure.Persistence.Data;

namespace TajMaster.Infrastructure.Persistence.Repositories;

public class CraftsmanRepository(ApplicationDbContext context) : Repository<Craftsman>(context), ICraftsmanRepository
{
    
    public override async Task<List<Craftsman>> GetAllAsync(PagingParameters pagingParameters, CancellationToken cancellationToken = default)
    {
        var query = context.Craftsmen
            .Include(u => u.Orders) 
            .Include(o => o.Reviews)
            .Include(a => a.Services)
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
    public async Task<IEnumerable<Craftsman>> GetCraftsmanByUserIdAsNoTrackingAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await context.Craftsmen
            .AsNoTracking()
            .Include(craftsmen => craftsmen.User)
            .Where(review => review.UserId == userId)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Craftsman>> GetBySpecializationAsync(string specialization, CancellationToken cancellationToken = default)
    {
        if (!Enum.TryParse<Specialization>(specialization, true, out var parsedSpecialization))
            throw new ArgumentException($"Invalid specialization: {specialization}");
        
        return await context.Craftsmen
            .Where(c => c.Specialization == parsedSpecialization)
            .ToListAsync(cancellationToken);
    }

    public IQueryable<Craftsman> GetAll()
    {
        return context.Set<Craftsman>();
    }

}


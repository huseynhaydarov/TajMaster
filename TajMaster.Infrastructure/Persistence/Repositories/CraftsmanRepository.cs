using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enums;
using TajMaster.Infrastructure.Persistence.Data;

namespace TajMaster.Infrastructure.Persistence.Repositories;

public class CraftsmanRepository(ApplicationDbContext context) : Repository<Craftsman>(context), ICraftsmanRepository
{
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


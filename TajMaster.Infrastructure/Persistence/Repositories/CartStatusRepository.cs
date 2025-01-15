using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Domain.Entities;
using TajMaster.Infrastructure.Persistence.Data;

namespace TajMaster.Infrastructure.Persistence.Repositories;

public class CartStatusRepository(ApplicationDbContext context) : Repository<CartStatusEntity>(context), ICartStatusRepository
{
    public async Task<CartStatusEntity> GetByNameAsync(string name, CancellationToken cancellationToken)
    {
        return (await context.CartStatuses
            .AsNoTracking()
            .FirstOrDefaultAsync(cs => cs.Name == name, cancellationToken))!;
    }

    public async Task<CartStatusEntity> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        return (await context.CartStatuses
            .AsNoTracking()
            .FirstOrDefaultAsync(cs => cs.Code == code, cancellationToken))!;
    }
}
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Application.Common.Pagination;
using TajMaster.Domain.Entities;
using TajMaster.Infrastructure.Persistence.Data;

namespace TajMaster.Infrastructure.Persistence.Repositories;

public class UserRepository(ApplicationDbContext context) : Repository<User>(context), IUserRepository
{
    public override async Task<List<User>> GetAllAsync(PagingParameters pagingParameters, CancellationToken cancellationToken = default)
    {
        var query = context.Users
            .Include(u => u.Orders) 
            .Include(o => o.Reviews) 
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
}
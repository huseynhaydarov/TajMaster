using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Domain.Entities;
using TajMaster.Infrastructure.Persistence.Data;

namespace TajMaster.Infrastructure.Persistence.Repositories;

public class UserRepository(ApplicationDbContext context) : Repository<User>(context), IUserRepository
{
}
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Domain.Entities;

namespace TajMaster.Infrastructure.Persistence.Repositories;

public class CraftsmanRepository(DbContext context) : Repository<Craftsman>(context), ICraftsmanRepository
{
}
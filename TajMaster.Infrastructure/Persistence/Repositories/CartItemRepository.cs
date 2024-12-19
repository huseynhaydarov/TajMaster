using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Domain.Entities;
using TajMaster.Infrastructure.Persistence.Data;

namespace TajMaster.Infrastructure.Persistence.Repositories;

public class CartItemRepository(ApplicationDbContext context) : Repository<CartItem>(context), ICartItemRepository
{
}
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Domain.Entities;
using TajMaster.Infrastructure.Persistence.Data;

namespace TajMaster.Infrastructure.Persistence.Repositories;

public class CartItemRepository(ApplicationDbContext context) : Repository<CartItem>(context), ICartItemRepository
{
    public async Task<List<CartItem>> GetCartItemsByCartIdAsync(int cartId)
    {
        return await context.CartItems
            .Where(ci => ci.CartId == cartId)
            .Include(ci => ci.Service)
            .ToListAsync();
    }

    public async Task DeleteByCartIdAsync(int cartId)
    {
        var cartItems = await context.CartItems
            .Where(ci => ci.CartId == cartId)
            .ToListAsync();

        context.CartItems.RemoveRange(cartItems);
        await context.SaveChangesAsync();
    }
}
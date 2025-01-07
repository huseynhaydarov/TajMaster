using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Domain.Entities;
using TajMaster.Infrastructure.Persistence.Data;

namespace TajMaster.Infrastructure.Persistence.Repositories;

public class CartRepository(ApplicationDbContext context) : Repository<Cart>(context), ICartRepository
{
    public async Task<Cart> GetCartByUserIdAsync(int userId)
    {
        return (await context.Carts
            .Include(c => c.CartItems)
            .ThenInclude(ci => ci.Service)
            .FirstOrDefaultAsync(c => c.UserId == userId))!;
        /*.FirstOrDefaultAsync(c => c.UserId == userId && c.CartStatus == CartStatus.active) ?? throw new InvalidOperationException();*/
    }

    public async Task UpdateAsync(Cart cart)
    {
        context.Carts.Update(cart);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int cartId)
    {
        var cart = await context.Carts.FindAsync(cartId);
        if (cart != null)
        {
            context.Carts.Remove(cart);
            await context.SaveChangesAsync();
        }
    }
}
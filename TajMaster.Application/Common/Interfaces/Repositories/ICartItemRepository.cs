using TajMaster.Domain.Entities;

namespace TajMaster.Application.Common.Interfaces.Repositories;

public interface ICartItemRepository : IRepository<CartItem>
{
    Task<List<CartItem>> GetCartItemsByCartIdAsync(Guid cartId);
    Task DeleteByCartIdAsync(Guid cartId); // Used to delete all items in a cart
}
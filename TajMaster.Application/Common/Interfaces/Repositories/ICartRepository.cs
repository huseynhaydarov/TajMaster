using TajMaster.Domain.Entities;

namespace TajMaster.Application.Common.Interfaces.Repositories;

public interface ICartRepository : IRepository<Cart>
{
    Task<Cart> GetCartByUserIdAsync(Guid userId);
    Task UpdateAsync(Cart cart);
    Task DeleteAsync(Guid cartId);
}
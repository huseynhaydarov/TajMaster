using TajMaster.Application.Common.Interfaces.Repositories;

namespace TajMaster.Application.Common.Interfaces.Data;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IServiceRepository ServiceRepository { get; }
    IReviewRepository ReviewRepository { get; }
    IOrderRepository OrderRepository { get; }
    IOrderItemRepository OrderItemRepository { get; }
    ICraftsmanRepository CraftsmanRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    ICartRepository CartRepository { get; }
    ICartItemRepository CartItemRepository { get; }
    
    ICartStatusRepository CartStatusRepository { get; }

    Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    void Dispose();
}
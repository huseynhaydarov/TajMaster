using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.Repositories;

namespace TajMaster.Infrastructure.Persistence.Data;

public class UnitOfWork(
    ApplicationDbContext context,
    IUserRepository userRepository,
    IServiceRepository serviceRepository,
    IReviewRepository reviewRepository,
    IOrderRepository orderRepository,
    ICraftsmanRepository craftsmanRepository,
    ICategoryRepository categoryRepository,
    IOrderItemRepository orderItemRepository,
    ICartRepository cartRepository,
    ICartItemRepository cartItemRepository) : IUnitOfWork, IDisposable
{
    private bool _disposed;
    public IOrderItemRepository OrderItemRepository => orderItemRepository;
    public ICartRepository CartRepository => cartRepository;
    public ICartItemRepository CartItemRepository => cartItemRepository;

    public IUserRepository UserRepository => userRepository;
    public IServiceRepository ServiceRepository => serviceRepository;
    public IReviewRepository ReviewRepository => reviewRepository;
    public IOrderRepository OrderRepository => orderRepository;
    public ICraftsmanRepository CraftsmanRepository => craftsmanRepository;
    public ICategoryRepository CategoryRepository => categoryRepository;

    public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                context.Dispose();

        _disposed = true;
    }
}
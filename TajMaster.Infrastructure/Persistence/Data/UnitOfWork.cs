using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.Repositories;

namespace TajMaster.Infrastructure.Persistence.Data;

public class UnitOfWork(DbContext context, IServiceProvider serviceProvider) : IUnitOfWork, IDisposable
{
    private bool _disposed = false;

    public IUserRepository UserRepository => serviceProvider.GetService<IUserRepository>()!;
    public IServiceRepository ServiceRepository => serviceProvider.GetService<IServiceRepository>()!;
    public IReviewRepository ReviewRepository => serviceProvider.GetService<IReviewRepository>()!;
    public IOrderRepository OrderRepository => serviceProvider.GetService<IOrderRepository>()!;
    public ICraftsmanRepository CraftsmanRepository => serviceProvider.GetService<ICraftsmanRepository>()!;
    public ICategoryRepository CategoryRepository => serviceProvider.GetService<ICategoryRepository>()!;
    

    public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
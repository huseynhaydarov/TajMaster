using TajMaster.Application.Common.Interfaces.Repositories;

namespace TajMaster.Application.Common.Interfaces.Data;

public interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    IServiceRepository ServiceRepository { get; }
    IReviewRepository ReviewRepository { get; }
    IOrderRepository OrderRepository { get; }
    ICraftsmanRepository CraftsmanRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    void Dispose();
}
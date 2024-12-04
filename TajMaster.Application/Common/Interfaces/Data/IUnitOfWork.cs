namespace TajMaster.Application.Common.Interfaces.Data;

public interface IUnitOfWork
{
    Task<int> CompleteAsync(CancellationToken cancellationToken = default);
    void Dispose();
}
namespace TajMaster.Domain.Abstractions;

public abstract class BaseEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
}
namespace TajMaster.Domain.Abstractions;

public class BaseEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
}
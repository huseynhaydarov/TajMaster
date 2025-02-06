namespace TajMaster.Domain.Abstractions;

public abstract class BaseEnum(string name, string code, bool isActive)
{
    private static readonly List<BaseEnum> Items = new();
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; } = name;
    public string Code { get; } = code;
    public bool IsActive { get; } = isActive;
}
namespace TajMaster.Domain.Abstractions;

public abstract class BaseStatusEnum(string name, string code, bool isActive) : BaseEntity
{ 
    public string Name { get; } = name;
    public string Code { get; } = code;
    public bool IsActive { get; } = isActive;

    public static IEnumerable<BaseStatusEnum> List() => throw new NotImplementedException();
    public static BaseStatusEnum FromId(Guid id) => throw new NotImplementedException();
    public static BaseStatusEnum FromCode(string code) => throw new NotImplementedException();
    public static BaseStatusEnum FromName(string name) => throw new NotImplementedException();
}
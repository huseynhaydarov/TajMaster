namespace TajMaster.Domain.Abstractions;

public abstract class BaseEnum(string name, string code, bool isActive)
{
    private static readonly List<BaseEnum> Items = new();
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Name { get; } = name;
    public string Code { get; } = code;
    public bool IsActive { get; } = isActive;

    protected static void AddItem(BaseEnum item)
    {
        Items.Add(item);
    }

    public static IEnumerable<BaseEnum> List()
    {
        return Items;
    }

    public static BaseEnum FromId(Guid id)
    {
        return Items.FirstOrDefault(item => item.Id == id)
               ?? throw new ArgumentException($"No enum with Id '{id}' found.");
    }

    public static BaseEnum FromCode(string code)
    {
        return Items.FirstOrDefault(item => item.Code == code)
               ?? throw new ArgumentException($"No enum with Code '{code}' found.");
    }

    public static BaseEnum FromName(string name)
    {
        return Items.FirstOrDefault(item => item.Name == name)
               ?? throw new ArgumentException($"No enum with Name '{name}' found.");
    }
}
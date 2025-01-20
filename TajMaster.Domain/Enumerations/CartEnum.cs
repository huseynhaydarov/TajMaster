using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Enumerations;

public class CartEnum : BaseEnum
{
    public static readonly CartEnum Created = 
        new(Guid.Parse("c750262b-312f-462d-9737-fd66e75efafe"), "Создан", "cart-created", true);
    public static readonly CartEnum Active = 
        new(Guid.Parse("a801a3e9-72e2-4ac6-b3ec-79890492c1cf"), "Активный", "cart-active", true);
    public static readonly CartEnum Inactive = 
        new(Guid.Parse("cb57360a-7021-4042-a971-abdafa48c28b"), "Неактивный", "cart-inactive", false);
    
    private CartEnum(Guid id, string name, string code, bool isActive)
        : base(name, code, isActive)
    {
        Id = id;
    }
    public new static IEnumerable<CartEnum> List() => new[] { Created, Active, Inactive };
}

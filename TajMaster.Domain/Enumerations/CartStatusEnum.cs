using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Enumerations;

public class CartStatusEnum : BaseEnum
{
    public static readonly CartStatusEnum Created =
        new(Guid.Parse("c750262b-312f-462d-9737-fd66e75efafe"), "Создан", "cart-created", true);

    public static readonly CartStatusEnum Active =
        new(Guid.Parse("a801a3e9-72e2-4ac6-b3ec-79890492c1cf"), "Активный", "cart-active", true);

    public static readonly CartStatusEnum Inactive =
        new(Guid.Parse("cb57360a-7021-4042-a971-abdafa48c28b"), "Неактивный", "cart-inactive", false);

    public static readonly CartStatusEnum Archived =
        new(Guid.Parse("2b34e0bc-41c4-4030-bb74-60af17b09634"), "Архивирован", "cart-archived", true);

    private CartStatusEnum(Guid id, string name, string code, bool isActive)
        : base(name, code, isActive)
    {
        Id = id;
    }

    public new static IEnumerable<CartStatusEnum> List()
    {
        return new[] { Created, Active, Inactive, Archived };
    }
}
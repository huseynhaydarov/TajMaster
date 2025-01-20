using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Enumerations;

public class CartStatusEnum : BaseStatusEnum
{
    public static readonly CartStatusEnum Created = 
        new(Guid.NewGuid(), "Создан", "cart-created", true);
    public static readonly CartStatusEnum Active = 
        new(Guid.NewGuid(), "Активный", "cart-active", true);
    public static readonly CartStatusEnum Inactive = 
        new(Guid.NewGuid(), "Неактивный", "cart-inactive", false);

    public CartStatusEnum(Guid id, string name, string code, bool isActive)
        : base(name, code, isActive) { }

    public static IEnumerable<CartStatusEnum> List() => new[] { Created, Active, Inactive };

    public static CartStatusEnum FromId(Guid id) => List().SingleOrDefault(s => s.Id == id) 
                                                    ?? throw new ArgumentException($"Invalid cart status ID: {id}");

    public static CartStatusEnum FromCode(string code) => List().SingleOrDefault(s => s.Code == code) 
                                                          ?? throw new ArgumentException($"Invalid cart status code: {code}");

    public static CartStatusEnum FromName(string name) => List().SingleOrDefault(s => s.Name == name) 
                                                          ?? throw new ArgumentException($"Invalid cart status name: {name}");
}
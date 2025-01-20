using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Enumerations;

public class OrderStatusEnum : BaseStatusEnum
{
    public static readonly OrderStatusEnum Pending = 
        new(Guid.NewGuid(), "В ожидании", "order-pending", true);
    public static readonly OrderStatusEnum Shipped = 
        new(Guid.NewGuid(), "Отправлен", "order-shipped", true);
    public static readonly OrderStatusEnum Cancelled = 
        new(Guid.NewGuid(), "Отменён", "order-cancelled", false);

    private OrderStatusEnum(Guid id, string name, string code, bool isActive)
        : base(name, code, isActive) { }

    public static IEnumerable<OrderStatusEnum> List() => new[] { Pending, Shipped, Cancelled };

    public static OrderStatusEnum FromId(Guid id) => List().SingleOrDefault(s => s.Id == id) 
                                                     ?? throw new ArgumentException($"Invalid order status ID: {id}");

    public static OrderStatusEnum FromCode(string code) => List().SingleOrDefault(s => s.Code == code) 
                                                           ?? throw new ArgumentException($"Invalid order status code: {code}");

    public static OrderStatusEnum FromName(string name) => List().SingleOrDefault(s => s.Name == name) 
                                                           ?? throw new ArgumentException($"Invalid order status name: {name}");
}
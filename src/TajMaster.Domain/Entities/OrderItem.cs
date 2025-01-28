using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities;

public class OrderItem : BaseEntity
{
    public Guid OrderId { get; set; }
    public Guid ServiceId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Order Order { get; set; } = null!;
    public Service Service { get; set; } = null!;
}
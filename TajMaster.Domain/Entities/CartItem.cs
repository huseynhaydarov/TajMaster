using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities;

public class CartItem : BaseEntity
{
    public int CartId { get; set; }
    public int ServiceId { get; set; }
    public int Quantity { get; set; }
    public Decimal Price { get; set; }
    public Cart Cart { get; set; } = null!;
    public Service Service { get; set; } = null!;
}
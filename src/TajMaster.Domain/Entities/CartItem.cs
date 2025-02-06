using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities;

public class CartItem : BaseEntity
{
    public Guid CartId { get; set; }
    public Guid ServiceId { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public Cart Cart { get; set; } = null!;
    public Service Service { get; set; } = null!;
}
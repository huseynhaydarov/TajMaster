using TajMaster.Domain.Abstractions;
using TajMaster.Domain.Enums;

namespace TajMaster.Domain.Entities;

public class Order : BaseEntity
{
    public int UserId { get; set; }
    public int CraftsmanId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public required string Address { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal TotalPrice => OrderItems?.Sum(x => x.Price * x.Quantity) ?? 0;
    public User User { get; set; } = null!;
    public Craftsman Craftsman { get; set; } = null!;
    public List<Review> Reviews { get; set; } = [];
    public List<OrderItem> OrderItems { get; set; } = [];
}
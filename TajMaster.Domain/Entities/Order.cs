using TajMaster.Domain.Abstractions;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Domain.Entities;

public class Order : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid CraftsmanId { get; set; }
    public Guid OrderStatusId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public required string Address { get; set; }
    public OrderStatus OrderStatus { get; set; } = null!;
    public decimal TotalPrice { get; set; }
    public User User { get; set; } = null!;
    public Craftsman Craftsman { get; set; } = null!;
    public List<Review> Reviews { get; set; } = [];
    public List<OrderItem> OrderItems { get; set; } = [];
}
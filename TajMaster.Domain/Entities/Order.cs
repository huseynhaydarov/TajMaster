using TajMaster.Domain.Abstractions;
using TajMaster.Domain.Enums;

namespace TajMaster.Domain.Entities;

public class Order : BaseEntity
{
    public int UserId { get; set; }
    public int CraftsmanId { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal TotalPrice { get; set; }
    public User User { get; set; } = null!;
    public Craftsman Craftsman { get; set; } = null!;
    public List<Review> Reviews { get; set; } = [];
    public List<Service> Services { get; set; } = [];
}
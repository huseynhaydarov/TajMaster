using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities;

public class OrderStatus : BaseEntity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    
    public List<Order> Orders { get; set; } = new List<Order>();
}
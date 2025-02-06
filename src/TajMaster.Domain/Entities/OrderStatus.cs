namespace TajMaster.Domain.Entities;

public class OrderStatus
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required bool IsActive { get; set; }
    public List<Order> Orders { get; set; } = new();
}
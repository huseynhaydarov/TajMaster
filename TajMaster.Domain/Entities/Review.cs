using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities;

public class Review : BaseEntity
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public int CraftsmanId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public Order Order { get; set; } = null!;
    public User User { get; set; } = null!;
    public Craftsman Craftsman { get; set; } = null!;
    
}
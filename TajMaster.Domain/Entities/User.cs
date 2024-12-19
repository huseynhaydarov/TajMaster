using TajMaster.Domain.Abstractions;
using TajMaster.Domain.Enums;

namespace TajMaster.Domain.Entities;

public class User : BaseEntity
{
    public required string FullName { get; set; }
    public string? Email { get; set; }
    public required string HashedPassword { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public Role Roles { get; set; }
    public DateTime RegisteredDate { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; }
    public Craftsman Craftsman { get; set; } = null!;
    public Cart Cart { get; set; } = null!;
    public List<Review> Reviews { get; set; } = [];
    public List<Order> Orders { get; set; } = [];
}
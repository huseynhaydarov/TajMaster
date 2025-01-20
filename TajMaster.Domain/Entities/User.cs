using TajMaster.Domain.Abstractions;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Domain.Entities;

public class User : BaseEntity
{
    public required string FullName { get; set; }
    public string? Email { get; set; }
    public required string HashedPassword { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public Guid UserRoleId { get; set; }
    public UserRole UserRole { get; set; } = null!;
    public DateTime RegisteredDate { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; }
    public Craftsman Craftsman { get; set; } = null!;
    public Cart Cart { get; set; } = null!;
    public List<Review> Reviews { get; set; } = [];
    public List<Order> Orders { get; set; } = [];
}
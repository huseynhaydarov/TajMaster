using TajMaster.Domain.Abstractions;
using TajMaster.Domain.Enumerations;
using TajMaster.Domain.Enums;

namespace TajMaster.Domain.Entities;

public class Craftsman : BaseEntity
{
    public Specialization Specialization { get; set; }
    public int Experience { get; set; }
    public int Rating { get; set; }
    public string? Description { get; set; }
    public string? ProfilePicture { get; set; }
    public bool IsAvialable { get; set; }
    public bool ProfileVerified { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = null!;
    public List<Order> Orders { get; set; } = [];
    public List<Service> Services { get; set; } = [];
    public List<Review> Reviews { get; set; } = [];
}
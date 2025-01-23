using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities;

public class Craftsman : BaseEntity
{
    public int Experience { get; set; }
    public int Rating { get; set; }
    public string? Description { get; set; }
    public string? ProfilePicture { get; set; }
    public bool IsAvialable { get; set; }
    public bool ProfileVerified { get; set; }
    public Guid SpecializationId { get; set; }
    public Specialization Specialization { get; set; } = null!;
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public List<Order> Orders { get; set; } = [];
    public List<Service> Services { get; set; } = [];
    public List<Review> Reviews { get; set; } = [];
}
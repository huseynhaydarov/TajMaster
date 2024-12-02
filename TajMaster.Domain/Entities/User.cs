using TajMaster.Domain.Abstractions;
using TajMaster.Domain.Enums;

namespace TajMaster.Domain.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; }
    public string? Email { get; set; }
    public string HashedPassword { get; set; }
    public string Phone { get; set; }
    public Role Roles { get; set; }
    public DateTime RegisteredDate { get; set; }
    public string? ProfilePicture { get; set; }
    public bool IsVerified { get; set; }    
    public bool IsActive { get; set; }
    public Craftsman? Craftsman { get; set; }
    public List<Review> Reviews { get; set; } = [];
    public List<Order> Orders { get; set; } = [];
    

}
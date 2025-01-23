namespace TajMaster.Domain.Entities;

public class UserRole
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Code { get; set; }
    public required bool IsActive { get; set; }

    public List<User> Users { get; set; } = new();
}
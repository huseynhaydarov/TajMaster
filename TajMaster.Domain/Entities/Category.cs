using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities;

public class Category : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public ICollection<CategoryService> CategoryServices { get; set; } = new List<CategoryService>();
}
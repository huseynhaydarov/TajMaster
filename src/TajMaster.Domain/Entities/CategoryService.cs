using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities;

public class CategoryService : BaseEntity
{
    public Guid ServiceId { get; set; }
    public Service Service { get; set; } = null!;

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}
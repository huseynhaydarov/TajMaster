using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<Service> Services { get; set; } = [];
}
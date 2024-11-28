using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities;

public class Service : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal BasePrice { get; set; }
    public int CraftsmanId { get; set; }
    public Craftsman Craftsman { get; set; }
    public List<Category> Categories { get; set; } = [];
}
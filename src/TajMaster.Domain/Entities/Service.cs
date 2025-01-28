using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities;

public class Service : BaseEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public decimal BasePrice { get; set; }
    public Guid CraftsmanId { get; set; }
    public Craftsman Craftsman { get; set; } = null!;
    public ICollection<CategoryService> CategoryServices { get; set; } = new List<CategoryService>();
    public List<OrderItem> OrderItems { get; set; } = [];
    public List<CartItem> CartItems { get; set; } = [];
}
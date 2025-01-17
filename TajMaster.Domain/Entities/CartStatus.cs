using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities
{
    public class CartStatus : BaseEntity
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        
        public List<Cart> Carts { get; set; } = [];
    }
}
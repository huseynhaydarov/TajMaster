using System.ComponentModel.DataAnnotations.Schema;
using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities
{
    public class Cart : BaseEntity
    {
        public Guid UserId { get; set; }

        public required string CartStatus { get; set; }

        [NotMapped] 
        public decimal Subtotal => CartItems?.Sum(x => x.Price * x.Quantity) ?? 0;

        public User User { get; set; } = null!;
        public List<CartItem> CartItems { get; set; } = [];
    }
}
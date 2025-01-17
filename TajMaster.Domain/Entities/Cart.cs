using System.ComponentModel.DataAnnotations.Schema;
using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities;

public class Cart : BaseEntity
{
    public Guid UserId { get; set; }
    
    public Guid CartStatusId { get; set; }
    
    public CartStatus CartStatus { get; set; } = null!;

    [NotMapped]
    public decimal Subtotal => CartItems?.Sum(x => x.Price * x.Quantity) ?? 0;

    public User User { get; set; } = null!;
    public List<CartItem> CartItems { get; set; } = new();
}
using System.ComponentModel.DataAnnotations.Schema;
using TajMaster.Domain.Abstractions;
using TajMaster.Domain.Enums;

namespace TajMaster.Domain.Entities;

public class Cart : BaseEntity
{
    public int UserId { get; set; }
    public CartStatus CartStatus { get; set; }

    [NotMapped] public decimal Subtotal => CartItems?.Sum(x => x.Price * x.Quantity) ?? 0;

    public User User { get; set; } = null!;
    public List<CartItem> CartItems { get; set; } = [];
}
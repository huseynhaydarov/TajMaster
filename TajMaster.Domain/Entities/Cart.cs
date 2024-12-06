using TajMaster.Domain.Abstractions;
using TajMaster.Domain.Enums;

namespace TajMaster.Domain.Entities;

public class Cart : BaseEntity
{
    public int UserId { get; set; }
    public CartStatus CartStatus { get; set; }
    public User User { get; set; } = null!;
    public List<CartItem> CartItems { get; set; } = [];
}
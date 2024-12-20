﻿using TajMaster.Domain.Abstractions;

namespace TajMaster.Domain.Entities;

public class Service : BaseEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public decimal BasePrice { get; set; }
    public int CraftsmanId { get; set; }
    public Craftsman Craftsman { get; set; } = null!;
    public List<Category> Categories { get; set; } = [];
    public List<OrderItem> OrderItems { get; set; } = [];
    public List<CartItem> CartItems { get; set; } = [];
}
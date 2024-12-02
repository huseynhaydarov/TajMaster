using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enums;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.HasOne(o => o.User)
            .WithMany(o => o.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        builder.HasOne(o => o.Craftsman)
            .WithMany(o => o.Orders)
            .HasForeignKey(o => o.CraftsmanId)
            .IsRequired();
        builder.Property(o => o.OrderDate)
            .IsRequired();
        builder.Property(o => o.CompletionDate)
            .IsRequired();
        builder.HasMany(o => o.Services)
            .WithMany(s => s.Orders)
            .UsingEntity("OrderServices");
        builder.Property(o => o.Status)
            .HasConversion(
                o => o.ToString(),
                o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o))
            .IsRequired();
        builder.Property(o => o.TotalPrice)
            .HasPrecision(12, 2)
            .IsRequired();
    }
}
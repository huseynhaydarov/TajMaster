using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.Property(t => t.CartId)
            .IsRequired();
        builder.Property(t => t.ServiceId)
            .IsRequired();
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Price)
            .HasPrecision(14, 2)
            .IsRequired();
        builder.Property(t => t.Quantity)
            .IsRequired();
        builder.HasOne(t => t.Service)
            .WithMany(s => s.CartItems)
            .HasForeignKey(t => t.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(t => t.Cart)
            .WithMany(c => c.CartItems)
            .HasForeignKey(t => t.CartId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
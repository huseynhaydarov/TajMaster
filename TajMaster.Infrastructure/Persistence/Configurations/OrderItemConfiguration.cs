using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.Id);  
        builder.Property(x => x.OrderId)
            .IsRequired();
        builder.Property(x => x.ServiceId)
            .IsRequired();
        builder.Property(x => x.Price)
            .HasPrecision(14, 2)
            .IsRequired();
        builder.Property(x => x.Quantity)
            .IsRequired();
        builder.HasOne(x => x.Order)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.Service)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
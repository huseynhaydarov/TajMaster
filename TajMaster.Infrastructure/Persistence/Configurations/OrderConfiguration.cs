using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;

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
        builder.Property(o => o.AppointmentDate)
            .IsRequired();
        builder.Property(o => o.Address)
            .HasMaxLength(150)
            .IsRequired();
        builder.HasMany(o => o.Reviews)
            .WithOne(o => o.Order)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(o => o.OrderStatus)
            .WithMany(o => o.Orders)
            .HasForeignKey(o => o.OrderStatusId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Property(o => o.TotalPrice)
            .HasPrecision(14, 2)
            .IsRequired();
    }
}
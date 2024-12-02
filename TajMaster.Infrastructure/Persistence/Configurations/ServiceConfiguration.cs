using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(s => s.Description)
            .HasMaxLength(5000)
            .IsRequired();
        builder.Property(s => s.BasePrice)
            .HasPrecision(14, 2)
            .IsRequired();
        builder.HasOne(s => s.Craftsman)
            .WithMany(s => s.Services)
            .HasForeignKey(s => s.CraftsmanId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }
}
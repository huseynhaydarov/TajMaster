using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class CraftsmanConfiguration : IEntityTypeConfiguration<Craftsman>
{
    public void Configure(EntityTypeBuilder<Craftsman> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Experience)
            .IsRequired();
        
        builder.Property(c => c.Rating)
            .IsRequired();
        
        builder.Property(c => c.Description)
            .HasMaxLength(500);
        
        builder.Property(c => c.ProfilePicture)
            .HasMaxLength(150);
        
        builder.Property(c => c.IsAvialable)
            .IsRequired();
        
        builder.Property(c => c.ProfileVerified)
            .IsRequired();
        
        builder.HasOne(c => c.User)
            .WithOne(c => c.Craftsman)
            .HasForeignKey<Craftsman>(c => c.UserId)
            .IsRequired();
        
        builder.HasMany(c => c.Services)
            .WithOne(c => c.Craftsman)
            .HasForeignKey(c => c.CraftsmanId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(c => c.Specialization)
            .WithMany()
            .HasForeignKey(c => c.Id)
            .IsRequired();
        
        builder.HasMany(c => c.Orders)
            .WithOne(c => c.Craftsman)
            .HasForeignKey(c => c.CraftsmanId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(c => c.Reviews)
            .WithOne(c => c.Craftsman)
            .HasForeignKey(c => c.CraftsmanId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
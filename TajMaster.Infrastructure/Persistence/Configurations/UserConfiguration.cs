using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FullName)
            .IsRequired();
        
        builder.HasIndex(x => x.Email)
            .IsUnique();
        
        builder.Property(x => x.HashedPassword)
            .HasMaxLength(256)
            .IsRequired();
        
        builder.Property(x => x.Phone)
            .HasMaxLength(9)
            .IsRequired(false);
        
        builder.Property(x => x.Address)
            .HasMaxLength(100)
            .IsRequired(false);
        
        builder.HasOne(x => x.UserRole)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.UserRoleId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(x => x.RegisteredDate)
            .IsRequired();
        
        builder.Property(x => x.IsActive)
            .IsRequired();
        
        builder.HasOne(x => x.Craftsman)
            .WithOne(x => x.User)
            .HasForeignKey<Craftsman>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
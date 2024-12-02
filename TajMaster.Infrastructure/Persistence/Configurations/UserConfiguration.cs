using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enums;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FullName)
            .IsRequired();
        builder.Property(x => x.Email)
            .HasMaxLength(50)
            .IsRequired(false);
        builder.Property(x => x.HashedPassword)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x => x.Phone)
            .HasMaxLength(9)
            .IsRequired();
        builder.Property(x => x.Roles)
            .HasConversion(
                x => x.ToString(),
                x => (Role)Enum.Parse(typeof(Role), x))
            .IsRequired();
        builder.Property(x => x.RegisteredDate)
            .IsRequired();
        builder.Property(x=> x.ProfilePicture)
            .IsRequired(false)
            .HasMaxLength(100);
        builder.Property(x => x.IsActive)
            .IsRequired();
        builder.Property(x => x.IsVerified)
            .IsRequired();
    }
}
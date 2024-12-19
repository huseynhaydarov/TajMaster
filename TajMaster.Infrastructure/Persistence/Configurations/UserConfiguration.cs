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
        builder.HasIndex(x => x.Email)
            .IsUnique();
        builder.Property(x => x.HashedPassword)
            .HasMaxLength(50)
            .IsRequired();
        builder.Property(x => x.Phone)
            .HasMaxLength(9)
            .IsRequired(false);
        builder.Property(x => x.Address)
            .HasMaxLength(100)
            .IsRequired(false);
        builder.Property(x => x.Roles)
            .HasConversion(
                x => x.ToString(),
                x => (Role)Enum.Parse(typeof(Role), x))
            .IsRequired();
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
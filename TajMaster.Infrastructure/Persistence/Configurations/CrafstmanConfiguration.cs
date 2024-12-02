using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enums;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class CrafstmanConfiguration : IEntityTypeConfiguration<Craftsman>
{
    public void Configure(EntityTypeBuilder<Craftsman> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Specialization)
            .HasConversion(
                c => c.ToString(),
                c => (Specialization)Enum.Parse(typeof(Specialization), c))
            .IsRequired();
        builder.Property(c => c.Experience)
            .IsRequired();
        builder.Property(c => c.Rating)
            .IsRequired();
        builder.Property(c => c.Description)
            .HasMaxLength(500)
            .IsRequired();
        builder.Property(c => c.Address)
            .HasMaxLength(100)
            .IsRequired();
        builder.HasOne(c => c.User)
            .WithOne(c => c.Craftsman)
            .HasForeignKey<Craftsman>(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class ReviewConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Property(r => r.OrderId)
            .IsRequired();
        builder.Property(r => r.UserId)
            .IsRequired();
        builder.Property(r => r.CraftsmanId)
            .IsRequired();
        builder.Property(r => r.Rating)
            .IsRequired();
        builder.Property(r => r.Comment)
            .HasMaxLength(300);
       
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class CartStatusConfiguration : IEntityTypeConfiguration<CartStatus>
{
    public void Configure(EntityTypeBuilder<CartStatus> builder)
    {
        builder.HasKey(cs => cs.Id);
        builder.Property(cs => cs.Name).IsRequired().HasMaxLength(50);
        builder.Property(cs => cs.Code).IsRequired().HasMaxLength(50);
    }
}
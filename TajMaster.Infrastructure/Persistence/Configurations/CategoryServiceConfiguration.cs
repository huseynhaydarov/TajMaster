using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class CategoryServiceConfiguration : IEntityTypeConfiguration<CategoryService>
{
    public void Configure(EntityTypeBuilder<CategoryService> builder)
    {

        builder.HasKey(cs => cs.Id);
        builder.Property(cs => cs.CategoryId).IsRequired();
        builder.Property(cs => cs.ServiceId).IsRequired();

        builder.HasOne(cs => cs.Service)
            .WithMany(s => s.CategoryServices)
            .HasForeignKey(cs => cs.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cs => cs.Category)
            .WithMany(c => c.CategoryServices)
            .HasForeignKey(cs => cs.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
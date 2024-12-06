using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();
        builder.Property(c => c.Description)
            .HasMaxLength(500)
            .IsRequired();
        builder.HasMany(c => c.Services)
            .WithMany(c => c.Categories)
            .UsingEntity<Dictionary<string, object>>(
                "CategoryServices",
                j => j.HasOne<Service>()
                    .WithMany()
                    .HasForeignKey("ServiceId") 
                    .OnDelete(DeleteBehavior.Cascade),
                j => j.HasOne<Category>()
                    .WithMany()
                    .HasForeignKey("CategoryId") 
                    .OnDelete(DeleteBehavior.Cascade));
    }
}
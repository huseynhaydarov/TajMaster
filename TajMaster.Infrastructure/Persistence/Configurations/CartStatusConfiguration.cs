using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class CartStatusConfiguration : IEntityTypeConfiguration<CartStatus>
{
    public void Configure(EntityTypeBuilder<CartStatus> builder)
    {
        builder.HasKey(cs => cs.Id);
        builder.Property(cs => cs.Name).IsRequired().HasMaxLength(50);
        builder.Property(cs => cs.Code).IsRequired().HasMaxLength(50);
        builder.Property(cs => cs.IsActive).IsRequired();

        builder.HasData(
            new CartStatus
            {
                Id = CartEnum.Created.Id,
                Name = CartEnum.Created.Name,
                Code = CartEnum.Created.Code,
                IsActive = CartEnum.Created.IsActive
            },
            new CartStatus
            {
                Id = CartEnum.Active.Id,
                Name = CartEnum.Active.Name,
                Code = CartEnum.Active.Code,
                IsActive = CartEnum.Active.IsActive
            },
            new CartStatus
            {
                Id = CartEnum.Inactive.Id,
                Name = CartEnum.Inactive.Name,
                Code = CartEnum.Inactive.Code,
                IsActive = CartEnum.Inactive.IsActive
            },
            new CartStatus
            {
                Id = CartEnum.Archived.Id,
                Name = CartEnum.Archived.Name,
                Code = CartEnum.Archived.Code,
                IsActive = CartEnum.Archived.IsActive
            }
        );
    }
}
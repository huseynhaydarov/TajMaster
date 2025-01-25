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
                Id = CartStatusEnum.Created.Id,
                Name = CartStatusEnum.Created.Name,
                Code = CartStatusEnum.Created.Code,
                IsActive = CartStatusEnum.Created.IsActive
            },
            new CartStatus
            {
                Id = CartStatusEnum.Active.Id,
                Name = CartStatusEnum.Active.Name,
                Code = CartStatusEnum.Active.Code,
                IsActive = CartStatusEnum.Active.IsActive
            },
            new CartStatus
            {
                Id = CartStatusEnum.Inactive.Id,
                Name = CartStatusEnum.Inactive.Name,
                Code = CartStatusEnum.Inactive.Code,
                IsActive = CartStatusEnum.Inactive.IsActive
            },
            new CartStatus
            {
                Id = CartStatusEnum.Archived.Id,
                Name = CartStatusEnum.Archived.Name,
                Code = CartStatusEnum.Archived.Code,
                IsActive = CartStatusEnum.Archived.IsActive
            }
        );
    }
}
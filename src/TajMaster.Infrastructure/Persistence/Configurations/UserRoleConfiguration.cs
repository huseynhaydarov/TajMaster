using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        
        builder.Property(x => x.Code).IsRequired().HasMaxLength(50);
        
        builder.Property(x => x.IsActive).IsRequired();

        builder.HasData(
            new UserRole
            {
                Id = UserRoleEnum.Craftsman.Id,
                Name = UserRoleEnum.Craftsman.Name,
                Code = UserRoleEnum.Craftsman.Code,
                IsActive = UserRoleEnum.Craftsman.IsActive
            },
            new UserRole
            {
                Id = UserRoleEnum.Customer.Id,
                Name = UserRoleEnum.Customer.Name,
                Code = UserRoleEnum.Customer.Code,
                IsActive = UserRoleEnum.Customer.IsActive
            },
            new UserRole
            {
                Id = UserRoleEnum.Admin.Id,
                Name = UserRoleEnum.Admin.Name,
                Code = UserRoleEnum.Admin.Code,
                IsActive = UserRoleEnum.Admin.IsActive
            },
            new UserRole
            {
                Id = UserRoleEnum.Guest.Id,
                Name = UserRoleEnum.Guest.Name,
                Code = UserRoleEnum.Guest.Code,
                IsActive = UserRoleEnum.Guest.IsActive
            }
        );
    }
}
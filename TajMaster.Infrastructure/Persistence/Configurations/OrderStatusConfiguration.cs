using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        builder.HasKey(os => os.Id);
        builder.Property(os => os.Id).IsRequired();
        builder.Property(os => os.Name).IsRequired().HasMaxLength(50);
        builder.Property(os => os.Code).IsRequired().HasMaxLength(50);
        builder.Property(os => os.IsActive).IsRequired();

        builder.HasData(
            new OrderStatus
            {
                Id = OrderStatusEnum.Pending.Id,
                Name = OrderStatusEnum.Pending.Name,
                Code = OrderStatusEnum.Pending.Code,
                IsActive = OrderStatusEnum.Pending.IsActive
            },
            new OrderStatus
            {
                Id = OrderStatusEnum.Accepted.Id,
                Name = OrderStatusEnum.Accepted.Name,
                Code = OrderStatusEnum.Accepted.Code,
                IsActive = OrderStatusEnum.Accepted.IsActive
            },
            new OrderStatus
            {
                Id = OrderStatusEnum.Cancelled.Id,
                Name = OrderStatusEnum.Cancelled.Name,
                Code = OrderStatusEnum.Cancelled.Code,
                IsActive = OrderStatusEnum.Cancelled.IsActive
            },
            new OrderStatus
            {
                Id = OrderStatusEnum.Completed.Id,
                Name = OrderStatusEnum.Completed.Name,
                Code = OrderStatusEnum.Completed.Code,
                IsActive = OrderStatusEnum.Completed.IsActive
            },
            new OrderStatus
            {
                Id = OrderStatusEnum.InProgress.Id,
                Name = OrderStatusEnum.InProgress.Name,
                Code = OrderStatusEnum.InProgress.Code,
                IsActive = OrderStatusEnum.InProgress.IsActive
            }
        );
    }
}
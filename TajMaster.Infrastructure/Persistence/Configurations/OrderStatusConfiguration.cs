using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;


namespace TajMaster.Infrastructure.Persistence.Configurations
{
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
                    Id = OrderEnum.Pending.Id,
                    Name = OrderEnum.Pending.Name,
                    Code = OrderEnum.Pending.Code,
                    IsActive = OrderEnum.Pending.IsActive
                },
                new OrderStatus
                {
                    Id = OrderEnum.Accepted.Id,
                    Name = OrderEnum.Accepted.Name,
                    Code = OrderEnum.Accepted.Code,
                    IsActive = OrderEnum.Accepted.IsActive
                },
                new OrderStatus
                {
                    Id = OrderEnum.Shipped.Id,
                    Name = OrderEnum.Shipped.Name,
                    Code = OrderEnum.Shipped.Code,
                    IsActive = OrderEnum.Shipped.IsActive
                },
                new OrderStatus
                {
                    Id = OrderEnum.Cancelled.Id,
                    Name = OrderEnum.Cancelled.Name,
                    Code = OrderEnum.Cancelled.Code,
                    IsActive = OrderEnum.Cancelled.IsActive
                },
                new OrderStatus
                {
                    Id = OrderEnum.Completed.Id,
                    Name = OrderEnum.Completed.Name,
                    Code = OrderEnum.Completed.Code,
                    IsActive = OrderEnum.Completed.IsActive
                },
                new OrderStatus
                {
                    Id = OrderEnum.InProgress.Id,
                    Name = OrderEnum.InProgress.Name,
                    Code = OrderEnum.InProgress.Code,
                    IsActive = OrderEnum.InProgress.IsActive
                }
            );
        }
    }
}

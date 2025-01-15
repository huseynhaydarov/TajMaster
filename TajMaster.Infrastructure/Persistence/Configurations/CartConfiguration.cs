using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;

namespace TajMaster.Infrastructure.Persistence.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.UserId)
                .IsRequired();

            builder.HasOne(t => t.User)
                .WithOne(t => t.Cart)
                .HasForeignKey<Cart>(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.CartItems)
                .WithOne(t => t.Cart)
                .HasForeignKey(t => t.CartId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Property(t => t.CartStatus).IsRequired();
 
            builder.Ignore(c => c.Subtotal);  // Ignore the calculated property
        }
    }
}
﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TajMaster.Domain.Entities;

namespace TajMaster.Infrastructure.Persistence.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Title)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(s => s.Description)
            .HasMaxLength(500)
            .IsRequired();
        
        builder.Property(s => s.BasePrice)
            .HasPrecision(14, 2)
            .IsRequired();
        
        builder.Property(s => s.CraftsmanId);
        
        builder.HasOne(c => c.Craftsman)
            .WithMany(s => s.Services)
            .HasForeignKey(c => c.CraftsmanId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasMany(s => s.CategoryServices)
            .WithOne(cs => cs.Service)
            .HasForeignKey(cs => cs.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(s => s.OrderItems)
            .WithOne(c => c.Service)
            .HasForeignKey(s => s.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(s => s.CartItems)
            .WithOne(c => c.Service)
            .HasForeignKey(s => s.ServiceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
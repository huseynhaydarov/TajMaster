using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TajMaster.Application.Common.Interfaces.BlobStorage;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.Repositories;
using TajMaster.Infrastructure.Persistence.Data;
using TajMaster.Infrastructure.Persistence.Repositories;
using TajMaster.Infrastructure.Storage;

namespace TajMaster.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var storageConnectionString = configuration.GetConnectionString("StorageAccount");

        services.AddDbContext<ApplicationDbContext>((db, options) => { options.UseNpgsql(connectionString); });

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IReviewRepository, ReviewRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<ICraftsmanRepository, CraftsmanRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICartItemRepository, CartItemRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        if (string.IsNullOrEmpty(storageConnectionString))
            throw new ArgumentNullException("Storage account connection string cannot be null or empty.");

        services.AddSingleton(_ => new BlobServiceClient(storageConnectionString));
        services.AddScoped<IBlobService, BlobService>();

        return services;
    }
}
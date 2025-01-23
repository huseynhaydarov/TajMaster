using Azure.Storage.Blobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TajMaster.Application.Common.Interfaces.BlobStorage;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.PasswordHasher;
using TajMaster.Infrastructure.Persistence.Data;
using TajMaster.Infrastructure.Storage;

namespace TajMaster.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var storageConnectionString = configuration.GetConnectionString("StorageAccount");

        if (string.IsNullOrEmpty(storageConnectionString))
        {
            throw new ArgumentNullException($"Storage account connection string cannot be null or empty.");
        }

        services.AddDbContext<ApplicationDbContext>((db, options) => { options.UseNpgsql(connectionString); });

        services.AddSingleton<IPasswordHasher, PasswordHasher.PasswordHasher>();

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        services.AddSingleton(_ => new BlobServiceClient(storageConnectionString));

        services.AddScoped<IBlobService, BlobService>();

        return services;
    }
}
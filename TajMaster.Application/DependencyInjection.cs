using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TajMaster.Application.Common.Behaviors;
using TajMaster.Application.Mappers;

namespace TajMaster.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(cfg => { cfg.AddProfile<AutoMapperConfiguration>(); });
        Assembly.GetExecutingAssembly();
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        
        return services;
    }
}
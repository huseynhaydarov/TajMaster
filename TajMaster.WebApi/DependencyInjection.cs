using Carter;
using TajMaster.WebApi.Middleware;

namespace TajMaster.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddAntiforgery();
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.MapCarter();

        app.UseExceptionHandler(_ => { });

        return app;
    }
}
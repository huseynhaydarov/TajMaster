using Carter;
using TajMaster.Application;
using TajMaster.Infrastructure;
using TajMaster.WebApi;
using TajMaster.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

using TajMaster.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

ConfigureMiddleware(app);

ApplyMigrations(app);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services
        .AddApplicationServices(configuration)
        .AddInfrastructureServices(configuration)
        .AddApiServices(configuration);
}

void ConfigureMiddleware(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger(); 
        app.UseSwaggerUI(c => 
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "TajMaster API v1");
        });
    }
    else
    {
        app.UseExceptionHandler("/Home/Error"); 
        app.UseHsts(); 
    }
    
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseMiddleware<CustomExceptionHandlerMiddleware>();
    app.UseMiddleware<RequestLoggingMiddleware>();
    app.MapCarter();
}

void ApplyMigrations(WebApplication app)
{
    try
    {
        var applicationDbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
        applicationDbContext.Database.MigrateAsync().Wait();
    }
    catch (Exception ex)
    {
        var logger = app.Services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while applying database migrations.");
        throw;
    }
}
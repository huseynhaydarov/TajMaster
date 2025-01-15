using System.Text;
using Carter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using TajMaster.Application.Common.Helpers;
using TajMaster.Application.Common.Interfaces.IdentityService;
using TajMaster.Domain.Enumerations;
using TajMaster.Infrastructure.AuthService;
using TajMaster.Infrastructure.Middlewares;

namespace TajMaster.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();
        services.AddAntiforgery();
        
        var jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();
        
        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings!.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.SecretKey!)),
                ClockSkew = TimeSpan.Zero
            };
            
            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    var logger = context.HttpContext.RequestServices
                        .GetRequiredService<ILogger<Program>>();
                    logger.LogError("Authentication failed: {Error}", 
                        context.Exception.Message);
                    return Task.CompletedTask;
                },
                OnForbidden = context =>
                {
                    var logger = context.HttpContext.RequestServices
                        .GetRequiredService<ILogger<Program>>();
                    logger.LogWarning("Forbidden access attempt for path: {Path}", 
                        context.HttpContext.Request.Path);
                    return Task.CompletedTask;
                }
            };
        });
        
        services.AddAuthorizationBuilder()
                    .AddPolicy("AdminPolicy", policy => 
                policy.RequireRole(Enum.GetName(typeof(Role), Role.Admin)!))
                    .AddPolicy("CustomerPolicy", policy => 
                policy.RequireRole(Enum.GetName(typeof(Role), Role.Customer)!))
                    .AddPolicy("AdminOrCustomer", policy => 
                policy.RequireRole(
                    Enum.GetName(typeof(Role), Role.Admin)!,
                    Enum.GetName(typeof(Role), Role.Customer)!
                ))
                    .SetDefaultPolicy(new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build());

        services.AddScoped<ITokenService, TokenService>();
        
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        if  (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage(); 
        }
        
        app.UseRouting();
        
        app.UseAuthentication();
        app.UseAuthorization();
        
        app.MapCarter();

        return app;
    }

    public static void AddMiddlewares(this WebApplication app)
    {
        app.UseMiddleware<CustomExceptionHandlerMiddleware>();
        app.UseMiddleware<RequestLoggingMiddleware>();
    }
}
using System.Text;
using Carter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TajMaster.Application.Common.Helpers;
using TajMaster.Application.Common.Interfaces.IdentityService;
using TajMaster.Application.Common.Interfaces.TokenService;
using TajMaster.Infrastructure.AuthService;
using TajMaster.WebApi.Services;

namespace TajMaster.WebApi;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddCarter();
        services.AddAntiforgery();

        var jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();

        services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings!.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(jwtSettings.SecretKey!)),
                    ClockSkew = TimeSpan.Zero
                };
                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        var logger = context.HttpContext.RequestServices
                            .GetRequiredService<ILogger<Program>>();
                        logger.LogError("Authentication failed: {Error}", context.Exception.Message);
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

        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminPolicy", policy 
                => policy.RequireRole("Admin"));
            options.AddPolicy("CustomerPolicy", policy 
                => policy.RequireRole("Customer"));
            options.AddPolicy("AdminOrCustomerPolicy", policy 
                => policy.RequireRole("Admin", "Customer"));
            options.AddPolicy("CraftsmanPolicy", policy 
                => policy.RequireRole("Craftsman"));
            options.AddPolicy("AdminOrCraftsmanPolicy", policy 
                => policy.RequireRole("Admin", "Craftsman"));
            options.AddPolicy("AdminOrCraftsmanOrCustomerPolicy", policy 
                => policy.RequireRole("Admin", "Craftsman", "Customer") );
        });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "TajMaster API", Version = "v1" });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme. " +
                              "`Bearer Generated-JWT-Token`",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            c.OperationFilter<SwaggerFileOperationFilter>();
        });

        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthenticatedUserService, AuthenticatedUserService>();

        return services;
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TajMaster.Application;
using TajMaster.Infrastructure;
using TajMaster.Infrastructure.Persistence.Data;
using TajMaster.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TajMaster API", Version = "v1" });
    
    c.OperationFilter<SwaggerFileOperationFilter>();
});

// Add services to the container.
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);


var app = builder.Build();

app.UseRouting();
app.UseAntiforgery();
app.UseApiServices();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var applicationDbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();
await applicationDbContext.Database.MigrateAsync();
app.Run();
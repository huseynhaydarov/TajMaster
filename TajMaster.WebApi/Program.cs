using Microsoft.EntityFrameworkCore;
using TajMaster.Application;
using TajMaster.Application.Mappers;
using TajMaster.Infrastructure;
using TajMaster.Infrastructure.Persistence.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration).Assembly);

builder.Services
    .AddApplicationServices(builder.Configuration)   
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();


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

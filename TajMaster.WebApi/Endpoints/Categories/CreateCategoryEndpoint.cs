using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Categories.Commands;
using TajMaster.Application.UseCases.Categories.Commands.Create;
using TajMaster.Application.UseCases.Users.Commands.Create;

namespace TajMaster.WebApi.Endpoints.Categories;

public class CreateCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/categories", async (ISender mediator, [FromBody] CreateCategoryCommand command) =>
            {
                var categoryId = await mediator.Send(command);
                return Results.Created($"/categories/{categoryId}", new { Id = categoryId });
            })
            .WithName("CreateCategoryEndpoint");
    }
}
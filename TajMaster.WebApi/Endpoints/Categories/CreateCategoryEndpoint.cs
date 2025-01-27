using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Categories.Commands.Create;

namespace TajMaster.WebApi.Endpoints.Categories;

public class CreateCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/categories", async ([FromBody] CreateCategoryCommand command, 
                ISender mediator) =>
            {
                var newCategory = await mediator.Send(command);

                return Results.Created($"/api/categories/{newCategory}", new { Id = newCategory });
            })
            .RequireAuthorization("AdminPolicy")
            .WithName("CreateCategoryEndpoint")
            .WithTags("Categories");
    }
}
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Categories.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Categories;

public class DeleteCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/category/{id}", async (ISender mediator, [FromRoute] Guid id) =>
            {
                var result = await mediator.Send(new DeleteCategoryCommand(id));
                return result ? Results.NoContent() : Results.NotFound(new { message = "Category not found."});
            })
            .WithName("DeleteCategoryEndpoint")
            .WithTags("Categories");
    }
}
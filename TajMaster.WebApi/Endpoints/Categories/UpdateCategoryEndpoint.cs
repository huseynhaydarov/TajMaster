using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Categories.Commands.Update;

namespace TajMaster.WebApi.Endpoints.Categories;

public class UpdateCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/categories/{id:guid}",
                async (ISender mediator, Guid id, [FromBody] UpdateCategoryCommand command) =>
                {
                    if (id != command.CategoryId) return Results.BadRequest(new { message = "Category ID mismatch." });
                    var result = await mediator.Send(command);

                    return result ? Results.NoContent() : Results.NotFound();
                })
            .RequireAuthorization("AdminPolicy")
            .WithName("UpdateCategoryEndpoint")
            .WithTags("Categories");
    }
}
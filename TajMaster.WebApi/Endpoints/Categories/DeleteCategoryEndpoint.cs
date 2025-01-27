using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TajMaster.Application.UseCases.Categories.Commands.Delete;

namespace TajMaster.WebApi.Endpoints.Categories;

public class DeleteCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/api/category/{id:guid}", async (ISender mediator, [FromRoute] Guid id) =>
            {
                await mediator.Send(new DeleteCategoryCommand(id));

                return Results.NoContent();
            })
            .RequireAuthorization("AdminPolicy")
            .WithName("DeleteCategoryEndpoint")
            .WithTags("Categories");
    }
}
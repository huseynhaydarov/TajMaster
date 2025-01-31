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
                async (Guid id, [FromBody] UpdateCategoryCommand command, ISender mediator, 
                    CancellationToken cancellationToken) =>
                {
                    if (id != command.CategoryId)
                    {
                        return Results.BadRequest();
                    } 
                    await mediator.Send(command, cancellationToken);

                    return Results.NoContent();
                })
            .RequireAuthorization("AdminPolicy")
            .WithName("UpdateCategoryEndpoint")
            .WithTags("Categories");
    }
}
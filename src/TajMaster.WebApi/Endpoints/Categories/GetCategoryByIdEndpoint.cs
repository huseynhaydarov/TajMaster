using Carter;
using MediatR;
using TajMaster.Application.UseCases.Categories.CategoryDtos;
using TajMaster.Application.UseCases.Categories.Queries.GetCategory;

namespace TajMaster.WebApi.Endpoints.Categories;

public class GetCategoryByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/categories/{id:guid}", async (Guid id, ISender mediator, 
                CancellationToken cancellationToken) =>
            {
                var category = await mediator.Send(new GetCategoryByIdQuery(id), cancellationToken);

                if (category == null!)
                {
                    return Results.NotFound();
                }

                return Results.Ok(category);
            })
            .RequireAuthorization("AdminOrCraftsmanPolicy")
            .WithName("GetCategoryByIdEndpoint")
            .WithTags("Categories")
            .Produces<CategoryDto>()
            .Produces(404);
    }
}
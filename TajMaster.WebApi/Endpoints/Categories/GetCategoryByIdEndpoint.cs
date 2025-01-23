using Carter;
using MediatR;
using TajMaster.Application.UseCases.Categories.CategoryDtos;
using TajMaster.Application.UseCases.Categories.Queries.GetCategory;

namespace TajMaster.WebApi.Endpoints.Categories;

public class GetCategoryByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/categories/{id:guid}", async (Guid id, ISender mediator) =>
            {
                var category = await mediator.Send(new GetCategoryByIdQuery(id));

                if (category == null!) return Results.NotFound(new { Message = $"Category with ID {id} not found." });

                return Results.Ok(category);
            })
            .RequireAuthorization("AdminOrCraftsmanOrCustomerPolicy")
            .WithName("GetCategoryByIdEndpoint")
            .WithTags("Categories")
            .Produces<CategoryDto>()
            .Produces(404);
    }
}
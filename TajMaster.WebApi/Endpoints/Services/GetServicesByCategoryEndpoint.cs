using Carter;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using TajMaster.Application.UseCases.DTO;
using TajMaster.Application.UseCases.Services.Queries.GetServiceByCategory;

namespace TajMaster.WebApi.Endpoints.Services;

public class GetServicesByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/services/category/{Id}", async (int categoryId, ISender sender) =>
                {
                    if (categoryId <= 0)
                        return Results.BadRequest(new { Message = "CategoryId must be a positive integer." });

                    var query = new GetServicesByCategoryQuery(categoryId);

                    var services = await sender.Send(query);

                    var serviceDto = services as ServiceDto[] ?? services.ToArray();
                    if (!serviceDto.Any())
                        return Results.NotFound(new { Message = $"No services found for category ID {categoryId}." });

                    return Results.Ok(serviceDto);
                })
            .WithName("GetServicesByCategoryEndpoint")
            .Produces<IEnumerable<ServiceDto>>();
    }
}
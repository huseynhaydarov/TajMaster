using Carter;
using MediatR;
using TajMaster.Application.UseCases.Services.Queries.GetServiceByCategory;
using TajMaster.Application.UseCases.Services.ServiceDtos;

namespace TajMaster.WebApi.Endpoints.Services;

public class GetServicesByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/services/category/{Id}", async (int categoryId, ISender sender) =>
            {
                if (categoryId <= 0)
                    return Results.BadRequest(new { Message = "CategoryId must be a positive integer." });

                var query = new GetServicesByCategoryQuery(categoryId);

                var services = await sender.Send(query);

                var serviceDto = services as ServiceSummaryDto[] ?? services.ToArray();
                if (!serviceDto.Any())
                    return Results.NotFound(new { Message = $"No services found for category ID {categoryId}." });

                return Results.Ok(serviceDto);
            })
            .WithName("GetServicesByCategoryEndpoint")
            .WithTags("Services")
            .Produces<IEnumerable<ServiceDetailDto>>();
    }
}
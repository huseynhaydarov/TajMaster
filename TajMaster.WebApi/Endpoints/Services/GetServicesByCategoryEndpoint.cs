using Carter;
using MediatR;
using TajMaster.Application.UseCases.Services.Queries.GetServiceByCategory;
using TajMaster.Application.UseCases.Services.ServiceDtos;

namespace TajMaster.WebApi.Endpoints.Services;

public class GetServicesByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/services/category/{Id}", async (Guid categoryId, ISender sender) =>
            {
                if (categoryId == Guid.Empty)
                    return Results.BadRequest(new { Message = "Invalid category ID." });

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
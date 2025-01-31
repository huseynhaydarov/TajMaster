using Carter;
using MediatR;
using TajMaster.Application.UseCases.Services.Queries.GetServiceByCategory;
using TajMaster.Application.UseCases.Services.ServiceDtos;

namespace TajMaster.WebApi.Endpoints.Services;

public class GetServicesByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/services/category/{categoryId:guid}", async (Guid categoryId, 
                ISender sender, CancellationToken cancellationToken) =>
            {
                if (categoryId == Guid.Empty)
                {
                    return Results.BadRequest();
                }

                var query = new GetServicesByCategoryQuery(categoryId);

                var services = await sender.Send(query, cancellationToken);

                var serviceDtos = services 
                    as ServiceSummaryDto[] ?? services.ToArray();

                if (!serviceDtos.Any())
                {
                    return Results.NotFound();
                }

                return Results.Ok(serviceDtos);
            })
            .RequireAuthorization("AdminPolicy")
            .WithName("GetServicesByCategoryEndpoint")
            .WithTags("Services")
            .Produces<IEnumerable<ServiceSummaryDto>>();
    }
}
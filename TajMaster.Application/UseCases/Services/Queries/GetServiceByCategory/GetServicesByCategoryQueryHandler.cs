using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Services.ServiceDtos;
using TajMaster.Application.UseCases.Services.ServiceExtensions;

namespace TajMaster.Application.UseCases.Services.Queries.GetServiceByCategory;

public class GetServicesByCategoryQueryHandler(
   IApplicationDbContext context)
    : IQueryHandler<GetServicesByCategoryQuery, IEnumerable<ServiceSummaryDto>>
{
    public async Task<IEnumerable<ServiceSummaryDto>> Handle(GetServicesByCategoryQuery query,
        CancellationToken cancellationToken)
    {
        var services = await context.Services
            .AsNoTracking()
            .Include(service => service.CategoryServices)
            .Where(service => service.CategoryServices.Any(category => category.CategoryId == query.CategoryId))
            .ToListAsync(cancellationToken);

        if (services == null || !services.Any())
        {
            throw new NotFoundException($"No services found for category with ID {query.CategoryId}");
        }

        return services.ToServiceDtoList();
    }
}
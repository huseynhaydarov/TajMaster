using TajMaster.Application.UseCases.Categories.CategoryDto;
using TajMaster.Application.UseCases.Services.ServiceDtos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Services.ServiceExtensions;

public static class ServiceMappingExtensions
{
    public static ServiceDetailDto ToServiceDto(this Service service)
    {
        return new ServiceDetailDto(
            service.Id,
            service.Title,
            service.Description,
            service.BasePrice,
            service.Categories?.Select(c => new CategoryDto(c.Id, c.Name, c.Description)).ToList() ??
            new List<CategoryDto>()
        );
    }

    private static ServiceSummaryDto ToServiceSummaryDto(this Service service)
    {
        return new ServiceSummaryDto(
            service.Id,
            service.Title,
            service.Description,
            service.BasePrice
        );
    }

    public static List<ServiceSummaryDto> ToServiceDtoList(this IEnumerable<Service> services)
    {
        return services.Select(service => service.ToServiceSummaryDto()).ToList();
    }
}
using TajMaster.Application.UseCases.Categories.CategoryDto;
using TajMaster.Application.UseCases.DTOs;
using TajMaster.Application.UseCases.OrderItems;
using TajMaster.Application.UseCases.Orders.OrderDtos;
using TajMaster.Application.UseCases.Services.ServiceDtos;
using TajMaster.Application.UseCases.Users.UserDtos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Services.ServiceExtensions;

public static class ServiceMappingExtensions
{
    public static ServiceDto MapToServiceDto(this Service service)
    {
        return new ServiceDto(
            service.Id,              
            service.Title,             
            service.Description,        
            service.BasePrice,          
            service.Categories?.Select(c => new CategoryDto(c.Id, c.Name, c.Description)).ToList() 
        );
    }
    
    public static List<ServiceDto> MapToServiceDtoList(this IEnumerable<Service> services)
    {
        return services.Select(service => service.MapToServiceDto()).ToList();
    }
}

using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Categories.CategoryDto;
using TajMaster.Application.UseCases.DTO;
using TajMaster.Application.UseCases.DTOs;
using TajMaster.Application.UseCases.Services.ServiceDtos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Services.Queries.GetServiceByCategory;

public class GetServicesByCategoryQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetServicesByCategoryQuery, IEnumerable<ServiceDto>>
{
    public async Task<IEnumerable<ServiceDto>> Handle(GetServicesByCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var services =
            await unitOfWork.ServiceRepository.GetServicesByCategoryIdAsNoTrackingAsync(request.CategoryId,
                cancellationToken);

        var enumerable = services as Service[] ?? services.ToArray();
        if (services == null || !enumerable.Any())
            throw new NotFoundException($"No services found for category with ID {request.CategoryId}");

        return enumerable.Select(service => new ServiceDto(
            service.Id,
            service.Title,
            service.Description,
            service.BasePrice,
            service.Categories.Select(category => new CategoryDto(
                category.Id,
                category.Name,
                category.Description
                )).ToList()
            )).ToList();
    }
}
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.DTO;

namespace TajMaster.Application.UseCases.Services.Queries.GetServices;

public class GetServicesQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetServicesQuery, PaginatedResult<ServiceDto>>
{
    public async Task<PaginatedResult<ServiceDto>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
    {
        var pagingParams = request.PagingParameters;

        var paginatedServices = await unitOfWork.ServiceRepository.GetAllAsync(pagingParams, cancellationToken);

        var totalCount = paginatedServices.Count();

        var serviceDtos = paginatedServices
            .Select(service => new ServiceDto(
                service.Id,
                service.Title,
                service.Description,
                service.BasePrice,
                service.Categories.Select(c => new CategoryDto(c.Id, c.Name, c.Description, null!)).ToList()
            ))
            .ToList();

        var paginatedResult = new PaginatedResult<ServiceDto>(
            (int)pagingParams.PageNumber!,
            (int)pagingParams.PageSize!,
            totalCount,
            serviceDtos
        );

        return paginatedResult;
    }
}
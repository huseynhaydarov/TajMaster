using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Services.ServiceDtos;
using TajMaster.Application.UseCases.Services.ServiceExtensions;

namespace TajMaster.Application.UseCases.Services.Queries.GetServices;

public class GetServicesQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetServicesQuery, PaginatedResult<ServiceSummaryDto>>
{
    public async Task<PaginatedResult<ServiceSummaryDto>> Handle(GetServicesQuery request,
        CancellationToken cancellationToken)
    {
        var pagingParams = request.PagingParameters;

        var paginatedServices = await unitOfWork.ServiceRepository.GetAllAsync(pagingParams, cancellationToken);

        var totalCount = paginatedServices.Count();

        var serviceDtos = paginatedServices.ToServiceDtoList();

        var paginatedResult = new PaginatedResult<ServiceSummaryDto>(
            (int)pagingParams.PageNumber!,
            (int)pagingParams.PageSize!,
            totalCount,
            serviceDtos
        );

        return paginatedResult;
    }
}
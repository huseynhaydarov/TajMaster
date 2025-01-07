using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Services.ServiceDtos;
using TajMaster.Application.UseCases.Services.ServiceExtensions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Services.Queries.GetServiceByCategory;

public class GetServicesByCategoryQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetServicesByCategoryQuery, IEnumerable<ServiceSummaryDto>>
{
    public async Task<IEnumerable<ServiceSummaryDto>> Handle(GetServicesByCategoryQuery request,
        CancellationToken cancellationToken)
    {
        var services =
            await unitOfWork.ServiceRepository.GetServicesByCategoryIdAsNoTrackingAsync(request.CategoryId,
                cancellationToken);

        var enumerable1 = services as Service[] ?? services.ToArray();
        var enumerable = services as Service[] ?? enumerable1.ToArray();
        if (services == null || !enumerable.Any())
            throw new NotFoundException($"No services found for category with ID {request.CategoryId}");

        return enumerable1.ToServiceDtoList();
    }
}
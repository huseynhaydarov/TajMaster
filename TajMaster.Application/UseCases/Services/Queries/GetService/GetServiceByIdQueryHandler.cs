using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Services.ServiceDtos;
using TajMaster.Application.UseCases.Services.ServiceExtensions;

namespace TajMaster.Application.UseCases.Services.Queries.GetService;

public class GetUserByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetServiceByIdQuery, ServiceDetailDto>
{
    public async Task<ServiceDetailDto> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.ServiceRepository.GetByIdAsync(request.ServiceId, cancellationToken);

        if (user == null)
            throw new NotFoundException($"Service with ID {request.ServiceId} not found.");

        return user.ToServiceDto();
    }
}
using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Services.ServiceDtos;
using TajMaster.Application.UseCases.Services.ServiceExtensions;

namespace TajMaster.Application.UseCases.Services.Queries.GetService;

public class GetUserByIdQueryHandler(
    IApplicationDbContext context)
    : IRequestHandler<GetServiceByIdQuery, ServiceDetailDto>
{
    public async Task<ServiceDetailDto> Handle(GetServiceByIdQuery query, CancellationToken cancellationToken)
    {
        var user = await context.Services
            .FirstOrDefaultAsync(s => s.Id == query.ServiceId, cancellationToken);

        if (user == null) throw new NotFoundException($"Service with ID {query.ServiceId} not found.");

        return user.ToServiceDto();
    }
}
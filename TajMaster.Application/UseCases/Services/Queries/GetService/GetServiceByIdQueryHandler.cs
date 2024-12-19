using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.Users.Exceptions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Services.Queries.GetService;

public class GetUserByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetServiceByIdQuery, Service>
{
    public async Task<Service> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.ServiceRepository.GetByIdAsync(request.ServiceId, cancellationToken);

        if (user == null)
            throw new UserNotFoundException($"Service with ID {request.ServiceId} not found.");

        return user;
    }
}
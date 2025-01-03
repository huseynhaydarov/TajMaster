using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;


namespace TajMaster.Application.UseCases.Services.Commands.Update;

public class UpdateServiceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateServiceCommand, bool>
{
    public async Task<bool> Handle(UpdateServiceCommand command, CancellationToken cancellationToken)
    {
        var service = await unitOfWork.ServiceRepository.GetByIdAsync(command.ServiceId, cancellationToken);

        if (service == null)
            throw new NotFoundException($"Service with ID {command.ServiceId} was not found");

        mapper.Map(command, service);

        await unitOfWork.ServiceRepository.UpdateAsync(service, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        return true;
    }
}
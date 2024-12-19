using MediatR;
using TajMaster.Application.Common.Interfaces.Data;

namespace TajMaster.Application.UseCases.Services.Commands.Delete;

public class DeleteServiceCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteServiceCommand, bool>
{
    public async Task<bool> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
    {
        var service = await unitOfWork.ServiceRepository.GetByIdAsync(request.ServiceId, cancellationToken);

        if (service == null) return await Task.FromResult(false);

        await unitOfWork.ServiceRepository.DeleteAsync(service, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateAvailability;

public class UpdateCraftsmanAvailabilityCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCraftsmanAvailabilityCommand, Unit>
{
    public async Task<Unit> Handle(UpdateCraftsmanAvailabilityCommand command, CancellationToken cancellationToken)
    {
        var craftsmen = await unitOfWork.CraftsmanRepository.GetByIdAsync(command.CraftsmanId, cancellationToken);
        
        if(craftsmen == null)
            throw new NotFoundException($"Craftsman with ID {command.CraftsmanId} not found.");

        craftsmen.IsAvialable = command.IsAvailable;
        
        await unitOfWork.CraftsmanRepository.UpdateAsync(craftsmen, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);
        
        return Unit.Value;
    }
    
}
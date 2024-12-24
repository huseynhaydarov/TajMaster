using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Update;

public class UpdateCraftsmanCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateCraftsmanCommand, bool>
{
    public async Task<bool> Handle(UpdateCraftsmanCommand command, CancellationToken cancellationToken)
    {
        var craftsman = await unitOfWork.CraftsmanRepository.GetByIdAsync(command.UserId, cancellationToken);

        if (craftsman == null)
            throw new NotFoundException($"Craftsman with ID {command.CraftsmanId} not found.");

        mapper.Map(command, craftsman);

        await unitOfWork.CraftsmanRepository.UpdateAsync(craftsman, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        return true;
    }
}
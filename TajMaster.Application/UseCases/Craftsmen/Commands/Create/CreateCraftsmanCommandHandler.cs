using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Entities;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Enums;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Create;

public class CreateCraftsmanCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateCraftsmanCommand, int>
{
    public async Task<int> Handle(CreateCraftsmanCommand command, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(command.UserId, cancellationToken);
        if (user == null)
            throw new NotFoundException("User not found.");

        if (user.Roles != Role.Craftsman)
            throw new InvalidOperationException("The user is not eligible to become a craftsman.");
        
        var craftsman = mapper.Map<Craftsman>(command);
        
        craftsman.UserId = command.UserId;

        craftsman = await unitOfWork.CraftsmanRepository.CreateAsync(craftsman, cancellationToken);
        
        await unitOfWork.CompleteAsync(cancellationToken);

        return craftsman.Id;
    }
}
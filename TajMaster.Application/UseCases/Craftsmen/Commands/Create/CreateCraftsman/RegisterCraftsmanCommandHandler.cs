using AutoMapper;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.PasswordHasher;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Create.CreateCraftsman;

public class RegisterCraftsmanCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IPasswordHasher passwordHasher) : ICommandHandler<CreateCraftsmanCommand, Guid>
{
    public async Task<Guid> Handle(CreateCraftsmanCommand command, CancellationToken cancellationToken)
    {
        var craftsman = mapper.Map<User>(command);
        
        craftsman.HashedPassword = passwordHasher.HashPassword(command.Password);
        
        craftsman.Roles = Role.Craftsman;
        
        craftsman = await unitOfWork.UserRepository.CreateAsync(craftsman, cancellationToken);

        craftsman.IsActive = true;
        
        await unitOfWork.CompleteAsync(cancellationToken);
        
        return craftsman.Id;
    }
}
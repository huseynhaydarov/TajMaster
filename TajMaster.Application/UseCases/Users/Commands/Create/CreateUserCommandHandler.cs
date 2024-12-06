using AutoMapper;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Users.Commands.Create;

public class CreateUserCommandHandler(IUnitOfWork unitOfWork, 
    IMapper mapper) : ICommandHandler<CreateUserCommand, int>
{
    public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
       var user = mapper.Map<User>(command);
       
       user = await unitOfWork.UserRepository.CreateAsync(user, cancellationToken);
       
       await unitOfWork.CompleteAsync(cancellationToken);
       
       return user.Id;
    }
}
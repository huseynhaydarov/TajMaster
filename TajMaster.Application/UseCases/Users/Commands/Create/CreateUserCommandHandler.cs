using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.PasswordHasher;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Cart.Commands;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Application.UseCases.Users.Commands.Create;

public class CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator, IPasswordHasher passwordHasher)
    : ICommandHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        if (command.Email != null)
        {
            var existingUser = await unitOfWork.UserRepository.FindByEmailAsync(command.Email, cancellationToken);
            if (existingUser != null) throw new ConflictException("The email address is already in use.");
        }
        
        var user = mapper.Map<User>(command);
        
        user.HashedPassword = passwordHasher.HashPassword(command.Password);
        
        user = await unitOfWork.UserRepository.CreateAsync(user, cancellationToken);

        user.IsActive = true;
        
        await unitOfWork.CompleteAsync(cancellationToken);

        var createCartCommand = new CreateCartCommand(user.Id);
        await mediator.Send(createCartCommand, cancellationToken);

        return user.Id;
    }
}
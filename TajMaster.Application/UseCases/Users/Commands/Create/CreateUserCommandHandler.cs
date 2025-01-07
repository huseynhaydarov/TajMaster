using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Cart.Commands;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Users.Commands.Create;

public class CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
    : ICommandHandler<CreateUserCommand, int>
{
    public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        if (command.Email != null)
        {
            var existingUser = await unitOfWork.UserRepository.FindByEmailAsync(command.Email, cancellationToken);
            if (existingUser != null) throw new ConflictException("The email address is already in use.");
        }

        var user = mapper.Map<User>(command);

        user = await unitOfWork.UserRepository.CreateAsync(user, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        var createCartCommand = new CreateCartCommand(user.Id);
        await mediator.Send(createCartCommand, cancellationToken);

        return user.Id;
    }
}
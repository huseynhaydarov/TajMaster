using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Users.Commands.Update;

public class UpdateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) :
    IRequestHandler<UpdateUserCommand, bool>
{
    public async Task<bool> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(command.UserId, cancellationToken);

        if (user?.Email == command.Email)
        {
            throw new ConflictException("Email already exists");
        }
        if (user == null)
            throw new NotFoundException($"User with ID {command.UserId} not found.");

        mapper.Map(command, user);

        await unitOfWork.UserRepository.UpdateAsync(user, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        return true;
    }
}
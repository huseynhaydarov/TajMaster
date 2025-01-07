using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Users.Commands.Delete;

public class DeleteUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserCommand, bool>
{
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user == null) 
            throw new NotFoundException($"User with ID {request.UserId} not found");

        await unitOfWork.UserRepository.DeleteAsync(user, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        return true;
    }
}
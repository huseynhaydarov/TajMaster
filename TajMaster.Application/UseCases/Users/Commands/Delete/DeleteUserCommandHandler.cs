using MediatR;
using TajMaster.Application.Common.Interfaces.Data;

namespace TajMaster.Application.UseCases.Users.Commands.Delete;

public class DeleteUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserCommand, bool>
{
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user == null) return await Task.FromResult(false);

        await unitOfWork.UserRepository.DeleteAsync(user, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}
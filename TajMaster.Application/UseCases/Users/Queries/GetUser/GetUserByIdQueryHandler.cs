using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.Users.Exceptions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Users.Queries.GetUser;

public class GetUserByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetUserByIdQuery, User>
{
    public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user == null)
            throw new UserNotFoundException($"User with ID {request.UserId} not found.");


        return user;
    }
}
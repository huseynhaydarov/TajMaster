using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.Users.Exceptions;
using TajMaster.Application.UseCases.Users.UserDtos;
using TajMaster.Application.UseCases.Users.UserExtensions;


namespace TajMaster.Application.UseCases.Users.Queries.GetUser;

public class GetUserByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.GetByIdAsync(request.UserId, cancellationToken);

        if (user == null)
            throw new UserNotFoundException($"User with ID {request.UserId} not found.");
        
        return user.MapToUserDto();
    }
}

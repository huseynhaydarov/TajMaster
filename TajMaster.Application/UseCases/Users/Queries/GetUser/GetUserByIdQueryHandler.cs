using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Users.UserDtos;
using TajMaster.Application.UseCases.Users.UserExtensions;

namespace TajMaster.Application.UseCases.Users.Queries.GetUser;

public class GetUserByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetUserByIdQuery, UserDetailDto>
{
    public async Task<UserDetailDto> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == query.UserId, cancellationToken);

        if (user == null)
        {
            throw new NullReferenceException();
        }
        
        return user.MapToUser();
    }
}
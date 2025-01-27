using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.Users.UserDtos;
using TajMaster.Application.UseCases.Users.UserExtensions;

namespace TajMaster.Application.UseCases.Users.Queries.GetUser;

public class GetUserByIdQueryHandler(
    IApplicationDbContext context) 
    : IQueryHandler<GetUserByIdQuery, UserDetailDto>
{
    public async Task<UserDetailDto> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .Include(u => u.UserRole)
            .Include(u => u.Orders)
            .ThenInclude(o => o.OrderStatus)
            .Include(u => u.Reviews)
            .FirstOrDefaultAsync(u => u.Id == query.UserId, cancellationToken);

        if (user == null)
        {
            throw new NullReferenceException();
        }

        return user.MapToUser();
    }
}
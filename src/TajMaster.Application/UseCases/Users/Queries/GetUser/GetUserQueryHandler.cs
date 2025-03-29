using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.IdentityService;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Users.UserDtos;
using TajMaster.Application.UseCases.Users.UserExtensions;

namespace TajMaster.Application.UseCases.Users.Queries.GetUser;

public class GetUserQueryHandler(
    IApplicationDbContext context,
    IAuthenticatedUserService authenticatedUserService) 
    : IQueryHandler<GetUserQuery, UserDetailDto>
{
    public async Task<UserDetailDto> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .AsNoTracking()
            .Include(u => u.UserRole)
            .Include(u => u.Orders)
                .ThenInclude(o => o.OrderStatus)
            .Include(u => u.Reviews)
            .AsSplitQuery()
            .FirstOrDefaultAsync(u => u.Id == authenticatedUserService.UserId 
                                      || authenticatedUserService.Roles.Contains("Admin"), cancellationToken);
        
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }

        return user.MapToUser();
        }
}
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Users.UserDtos;
using TajMaster.Application.UseCases.Users.UserExtensions;

namespace TajMaster.Application.UseCases.Users.Queries.GetUsers;

public class GetUsersQueryHandler(IApplicationDbContext context)
    : IQueryHandler<GetUsersQuery, PaginatedResult<UserSummaryDto>>
{
    public async Task<PaginatedResult<UserSummaryDto>> Handle(GetUsersQuery query,
        CancellationToken cancellationToken)
    {
        var pagingParams = query.PagingParameters;

        var request = context.Users
            .AsNoTracking()
            .Include(u => u.Orders)
            .Include(u => u.Reviews)
            .AsQueryable();

        request = pagingParams.OrderByDescending == true
            ? request.OrderByDescending(u => u.Id)
            : request.OrderBy(u => u.Id);

        var totalCount = await request.CountAsync(cancellationToken);

        var paginatedUsers = await request
            .Skip(pagingParams.Skip)
            .Take(pagingParams.Take)
            .ToListAsync(cancellationToken);

        var usersDto = paginatedUsers.ToUserDtoList();

        return new PaginatedResult<UserSummaryDto>(
            (int)pagingParams.PageNumber!,
            (int)pagingParams.PageSize!,
            totalCount,
            usersDto);
    }
}
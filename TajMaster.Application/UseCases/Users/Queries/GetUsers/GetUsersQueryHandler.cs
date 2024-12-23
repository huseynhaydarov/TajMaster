using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.DTO;

namespace TajMaster.Application.UseCases.Users.Queries.GetUsers;

public class GetUsersQueryHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetUsersQuery, PaginatedResult<UserDto>>
{
    public async Task<PaginatedResult<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var pagingParams = request.PagingParameters;

        var paginatedUsers = await unitOfWork.UserRepository.GetAllAsync(pagingParams, cancellationToken);

        var totalCount = paginatedUsers.Count();

        var usersDto = paginatedUsers
            .Select(user => new UserDto(
                user.Id,
                user.FullName,
                user.Email,
                user.Phone,
                user.Address,
                user.Roles,
                user.RegisteredDate,
                user.IsActive
            ))
            .ToList();

        var paginatedResult = new PaginatedResult<UserDto>(
            (int)pagingParams.PageNumber!,
            (int)pagingParams.PageSize!,
            totalCount,
            usersDto
        );

        return paginatedResult;
    }
}
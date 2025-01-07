using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Users.UserDtos;
using TajMaster.Application.UseCases.Users.UserExtensions;

namespace TajMaster.Application.UseCases.Users.Queries.GetUsers;

public class GetUsersQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetUsersQuery, PaginatedResult<UserSummaryDto>>
{
    public async Task<PaginatedResult<UserSummaryDto>> Handle(GetUsersQuery request,
        CancellationToken cancellationToken)
    {
        var pagingParams = request.PagingParameters;

        var paginatedUsers = await unitOfWork.UserRepository.GetAllAsync(pagingParams, cancellationToken);

        var totalCount = paginatedUsers.Count;

        var usersDto = paginatedUsers.ToUserDtoList();

        return new PaginatedResult<UserSummaryDto>(
            (int)pagingParams.PageNumber!,
            (int)pagingParams.PageSize!,
            totalCount,
            usersDto);
    }
}
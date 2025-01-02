using AutoMapper;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Users.UserDtos;
using TajMaster.Application.UseCases.Users.UserExtensions;


namespace TajMaster.Application.UseCases.Users.Queries.GetUsers;

public class GetUsersQueryHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetUsersQuery, PaginatedResult<GetUsersDto>>
{
    public async Task<PaginatedResult<GetUsersDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var pagingParams = request.PagingParameters;

        var paginatedUsers = await unitOfWork.UserRepository.GetAllAsync(pagingParams, cancellationToken);

        var totalCount = paginatedUsers.Count;
        
        var usersDto = paginatedUsers
            .Select(user => user.ToUsersDto());

        return new PaginatedResult<GetUsersDto>(
            (int)pagingParams.PageNumber!,
            (int)pagingParams.PageSize!,
            totalCount,
            usersDto);
    }
}

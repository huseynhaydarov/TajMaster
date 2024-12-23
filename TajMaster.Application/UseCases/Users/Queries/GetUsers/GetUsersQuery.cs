using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.DTO;

namespace TajMaster.Application.UseCases.Users.Queries.GetUsers;

public record GetUsersQuery(PagingParameters PagingParameters) : IQuery<PaginatedResult<UserDto>>;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.DTO;

namespace TajMaster.Application.UseCases.Users.Queries;

public record GetUsersQuery(PagingParameters PagingParameters) : IQuery<PaginatedResult<UserDto>>;
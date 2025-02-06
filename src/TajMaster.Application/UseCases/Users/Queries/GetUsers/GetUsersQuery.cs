using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Users.UserDtos;

namespace TajMaster.Application.UseCases.Users.Queries.GetUsers;

public record GetUsersQuery(PagingParameters PagingParameters) : IQuery<PaginatedResult<UserSummaryDto>>;
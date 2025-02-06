using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Users.UserDtos;

namespace TajMaster.Application.UseCases.Users.Queries.GetUser;

public record GetUserByIdQuery(Guid UserId) : IQuery<UserDetailDto>;
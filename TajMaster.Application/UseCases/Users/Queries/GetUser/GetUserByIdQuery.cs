using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Users.Queries.GetUser;

public record GetUserByIdQuery(int UserId) : IQuery<User>;
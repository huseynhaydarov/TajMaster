using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.DTO;
using TajMaster.Application.UseCases.Users.UserDtos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Users.Queries.GetUser;

public record GetUserByIdQuery(int UserId) : IQuery<UserDto>;
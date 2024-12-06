using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enums;

namespace TajMaster.Application.UseCases.Users.Commands.Create;

public record CreateUserCommand(
    string FullName,
    string? Email,
    string HashedPassword,
    string Phone,
    Role Roles,
    DateTime RegisterDate,
    string? ProfilePicture,
    bool IsVerified,
    bool IsActive,
    List<Review> Reviews,
    List<Order> Orders) 
    : IRequest<int>, ICommand<int>;

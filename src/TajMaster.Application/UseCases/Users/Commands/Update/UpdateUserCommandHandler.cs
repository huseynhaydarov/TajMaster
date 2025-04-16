using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.IdentityService;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Application.UseCases.Users.Commands.Update;

public class UpdateUserCommandHandler(
    IApplicationDbContext context,
    IAuthenticatedUserService authenticatedUserService)
    : ICommandHandler<UpdateUserCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        if (authenticatedUserService.UserId == null)
        {
            throw new UnauthorizedAccessException("No authenticated user.");
        }

        if (authenticatedUserService.Roles.Contains(UserRoleEnum.Admin.ToString()))
        {
            throw new ForbiddenException("Admins are not allowed to update users.");
        }

        var currentUserId = authenticatedUserService.UserId.Value;

        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == currentUserId, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException("User not found.");
        }

        if (!string.IsNullOrEmpty(command.Email) && command.Email != user.Email)
        {
            var emailExists = await context.Users
                .AnyAsync(u => u.Email == command.Email && u.Id != user.Id, cancellationToken);

            if (emailExists)
            {
                throw new ConflictException("The email address is already in use.");
            }

            user.Email = command.Email;
        }

        user.FullName = command.FullName ?? string.Empty;
        user.Phone = command.Phone;
        user.Address = command.Address;

        await context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
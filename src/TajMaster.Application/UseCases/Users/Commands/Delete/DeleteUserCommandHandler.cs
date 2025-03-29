using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.IdentityService;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Users.Commands.Delete;

public class DeleteUserCommandHandler(
    IApplicationDbContext context,
    IAuthenticatedUserService authenticatedUserService) 
    : IRequestHandler<DeleteUserCommand, Unit>
{
    public async Task<Unit> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        if (authenticatedUserService.UserId != null)
        {
            var currentUserId = authenticatedUserService.UserId.Value;
            var currentUserRoles = authenticatedUserService.Roles;
        
            if (currentUserId != command.UserId && !currentUserRoles.Contains("Admin"))
            {
                throw new ForbiddenException("You are not allowed to delete this user.");
            }
        }

        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Id == authenticatedUserService.UserId, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException($"User not found");
        }

        context.Users.Remove(user);

        await context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
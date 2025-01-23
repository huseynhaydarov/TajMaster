using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Users.Commands.Delete;

public class DeleteUserCommandHandler(
    IApplicationDbContext context) 
    : IRequestHandler<DeleteUserCommand, bool>
{
    public async Task<bool> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Id == command.UserId, cancellationToken);

        if (user == null)
        {
            throw new NotFoundException($"User with ID {command.UserId} not found");
        }

        context.Users.Remove(user);

        await context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}
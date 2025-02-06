using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Users.Commands.Update;

public class UpdateUserCommandHandler(
    IApplicationDbContext context,
    IMapper mapper)
    : ICommandHandler<UpdateUserCommand, Unit>
{
    public async Task<Unit> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Id == command.UserId, cancellationToken);

        if (user?.Email == command.Email)
        {
            throw new ConflictException("Email already exists");
        }

        if (user == null)
        {
            throw new NotFoundException($"User with ID {command.UserId} not found.");
        }

        mapper.Map(command, user);

        context.Users.Update(user);

        await context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.PasswordHasher;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Carts.Commands;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Application.UseCases.Users.Commands.Create;

public class CreateUserCommandHandler(
    IApplicationDbContext context,
    IMapper mapper,
    IMediator mediator,
    IPasswordHasher passwordHasher)
    : ICommandHandler<CreateUserCommand, Guid>
{
    public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        if (command.Email != null)
        {
            var existingUser = await context.Users
                .FirstOrDefaultAsync(u => u.Email == command.Email, cancellationToken);

            if (existingUser != null) throw new ConflictException("The email address is already in use.");
        }

        var user = mapper.Map<User>(command);

        user.HashedPassword = passwordHasher.HashPassword(command.Password);

        await context.Users.AddAsync(user, cancellationToken);

        user.IsActive = true;

        user.UserRoleId = UserRoleEnum.Customer.Id;

        await context.SaveChangesAsync(cancellationToken);

        var createCartCommand = new CreateCartCommand(user.Id);

        await mediator.Send(createCartCommand, cancellationToken);

        return user.Id;
    }
}
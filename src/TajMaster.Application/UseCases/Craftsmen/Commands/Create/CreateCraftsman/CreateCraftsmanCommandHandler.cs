using AutoMapper;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.PasswordHasher;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Create.CreateCraftsman;

public class CreateCraftsmanCommandHandler(
    IApplicationDbContext context,
    IMapper mapper,
    IPasswordHasher passwordHasher)
    : ICommandHandler<CreateCraftsmanCommand, Guid>
{
    public async Task<Guid> Handle(CreateCraftsmanCommand command, CancellationToken cancellationToken)
    {
        var craftsman = mapper.Map<User>(command);

        craftsman.HashedPassword = passwordHasher.HashPassword(command.Password);

        craftsman.UserRoleId = UserRoleEnum.Craftsman.Id;

        context.Users.Add(craftsman);

        craftsman.IsActive = true;

        await context.SaveChangesAsync(cancellationToken);

        return craftsman.Id;
    }
}
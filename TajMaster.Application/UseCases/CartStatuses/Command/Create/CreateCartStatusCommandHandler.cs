using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.CartStatuses.Command.Create;

public class CreateCartStatusCommandHandler(
    IApplicationDbContext context,
    IMapper mapper)
    : IRequestHandler<CreateCartStatusCommand, Guid>
{
    public async Task<Guid> Handle(CreateCartStatusCommand command, CancellationToken cancellationToken)
    {
        var cartStatus = mapper.Map<CartStatus>(command);

        context.CartStatuses.Add(cartStatus);

        await context.SaveChangesAsync(cancellationToken);

        return cartStatus.Id;
    }
}
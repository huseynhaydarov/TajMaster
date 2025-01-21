using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.OrderStatuses.Commands.Create;

public class CreateOrderStatusCommandHandler(
    IApplicationDbContext context,
    IMapper mapper)
    : IRequestHandler<CreateOrderStatusCommand, Guid>
{
    public async Task<Guid> Handle(CreateOrderStatusCommand command, CancellationToken cancellationToken)
    {
        var orderStatus = mapper.Map<OrderStatus>(command);

        context.OrderStatuses.Add(orderStatus);

        await context.SaveChangesAsync(cancellationToken);

        return orderStatus.Id;
    }
}
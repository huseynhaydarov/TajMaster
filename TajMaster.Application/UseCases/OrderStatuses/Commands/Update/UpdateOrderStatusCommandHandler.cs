using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.OrderStatuses.Commands.Update;

public class UpdateOrderStatusCommandHandler(
    IApplicationDbContext context,
    IMapper mapper)
    : IRequestHandler<UpdateOrderStatusCommand, bool>
{
    public async Task<bool> Handle(UpdateOrderStatusCommand command, CancellationToken cancellationToken)
    {
        var orderStatus = await context.OrderStatuses
            .FirstOrDefaultAsync(cs => cs.Id == command.OrderStatusId, cancellationToken);

        if (orderStatus == null) throw new NotFoundException("Order status could not be found");

        mapper.Map(command, orderStatus);

        await context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}
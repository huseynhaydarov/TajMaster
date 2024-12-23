using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Orders.Create;

public class CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateOrderCommand, int>
{
    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = mapper.Map<Order>(request);
        
        order = await unitOfWork.OrderRepository.CreateAsync(order, cancellationToken);
        
        await unitOfWork.CompleteAsync(cancellationToken);
        
        return order.Id;
    }
}
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Application.UseCases.Orders.Create;

public class CreateOrderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand, Guid>
{
    public async Task<Guid> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var cart = await unitOfWork.CartRepository.GetCartByUserIdAsync(command.UserId);
        if (cart == null || !cart.CartItems.Any())
            throw new InvalidOperationException("Cart is empty or not found.");
        
        var completedStatus = await unitOfWork.CartStatusRepository.GetByNameAsync("Completed", cancellationToken);
        if (completedStatus == null)
            throw new InvalidOperationException("Cart status 'Completed' not found.");

        cart.CartStatus = completedStatus.ToString()!;
        
        var order = new Order
        {
            UserId = command.UserId,
            Address = command.Address,
            AppointmentDate = command.AppointmentDate,
            CraftsmanId = command.CraftsmanId,
            Status = OrderStatus.Pending,
            TotalPrice = cart.Subtotal
        };

        var orderItems = cart.CartItems.Select(cartItem => new OrderItem
        {
            ServiceId = cartItem.ServiceId,
            Quantity = cartItem.Quantity,
            Price = cartItem.Price
        }).ToList();

        order.OrderItems = orderItems;

   
        cart.CartItems.Clear();

        
        var archivedStatus = await unitOfWork.CartStatusRepository.GetByNameAsync("Archived", cancellationToken);
        if (archivedStatus == null)
            throw new InvalidOperationException("Cart status 'Archived' not found.");

        cart.CartStatus = archivedStatus.ToString()!;

        await unitOfWork.CartRepository.UpdateAsync(cart);

        order = await unitOfWork.OrderRepository.CreateAsync(order, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        return order.Id;
    }
}
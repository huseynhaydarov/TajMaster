using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;
using TajMaster.Domain.Enums;

namespace TajMaster.Application.UseCases.Orders.Create;

public class CreateOrderCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateOrderCommand, int>
{
    public async Task<int> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        var cart = await unitOfWork.CartRepository.GetCartByUserIdAsync(command.UserId);
        if (cart == null || !cart.CartItems.Any())
            throw new InvalidOperationException("Cart is empty or not found.");

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

        cart.CartStatus = CartStatus.completed;

        // Delete the CartItems before clearing the collection
        foreach (var cartItem in cart.CartItems.ToList())
            await unitOfWork.CartItemRepository.DeleteAsync(cartItem,
                cancellationToken); // Assuming you have a CartItemRepository with Delete method

        // Clear the CartItems collection
        cart.CartItems.Clear();

        // Update the cart
        await unitOfWork.CartRepository.UpdateAsync(cart);

        // Optionally: Archive the cart after the order
        cart.CartStatus = CartStatus.archived;

        // Create the order in the database
        order = await unitOfWork.OrderRepository.CreateAsync(order, cancellationToken);

        // Commit all changes
        await unitOfWork.CompleteAsync(cancellationToken);

        return order.Id;
    }
}
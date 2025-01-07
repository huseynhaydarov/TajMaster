using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;

namespace TajMaster.Application.UseCases.CartItem.Commands.Create;

public class AddCartItemCommandHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<AddCartItemCommand, int>
{
    public async Task<int> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
    {
        var cart = await unitOfWork.CartRepository.GetByIdAsync(request.CartId, cancellationToken);
        if (cart == null)
            throw new InvalidOperationException("Cart not found.");
        
        var existingItem = cart.CartItems.FirstOrDefault(ci => ci.ServiceId == request.ServiceId);
        if (existingItem != null)
        {
            existingItem.Quantity += 1;
            existingItem.Price = request.Price * existingItem.Quantity;

            await unitOfWork.CartItemRepository.UpdateAsync(existingItem, cancellationToken);
        }
        else
        {
            var newCartItem = new Domain.Entities.CartItem
            {
                CartId = request.CartId,
                ServiceId = request.ServiceId,
                Price = request.Price,
                Quantity = 1
            };

            await unitOfWork.CartItemRepository.CreateAsync(newCartItem, cancellationToken);
        }
        
        await unitOfWork.CompleteAsync(cancellationToken);
        
        return existingItem?.Id ?? cart.CartItems.Last().Id;
    }
}
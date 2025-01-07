using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.CartItem.Commands.Delete.DeleteByCartItem;

public class DeleteCartItemCommandHandler(IUnitOfWork unitOfWork)
    : ICommandHandler<DeleteCartItemCommand, bool>
{
    public async Task<bool> Handle(DeleteCartItemCommand request, CancellationToken cancellationToken)
    {
        var cartItem = await unitOfWork.CartItemRepository.GetByIdAsync(request.CartItemId, cancellationToken);

        if (cartItem == null)
            throw new NotFoundException($"Cart item with ID {request.CartItemId} not found.");

        await unitOfWork.CartItemRepository.DeleteAsync(cartItem, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);

        return true;
    }
}
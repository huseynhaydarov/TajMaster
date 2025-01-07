using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;

namespace TajMaster.Application.UseCases.CartItem.Commands.Delete.DeleteByCart;

public class DeleteCartItemsByCartIdCommandHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<DeleteCartItemsByCartIdCommand, bool>
{
    public async Task<bool> Handle(DeleteCartItemsByCartIdCommand request, CancellationToken cancellationToken)
    {
        await unitOfWork.CartItemRepository.DeleteByCartIdAsync(request.CartId);

        await unitOfWork.CompleteAsync(cancellationToken);

        return true;
    }
}
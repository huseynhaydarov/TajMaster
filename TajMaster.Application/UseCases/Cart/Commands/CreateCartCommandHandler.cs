using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Application.UseCases.Cart.Commands;

public class CreateCartCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCartCommand, Guid>
{
    public async Task<Guid> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        var activeStatus =  await unitOfWork.CartStatusRepository.GetByNameAsync("Active", cancellationToken);
        if (activeStatus == null)
            throw new InvalidOperationException("Cart status 'Active' not found.");


        var newCart = new Domain.Entities.Cart
        {
            UserId = command.UserId,
            CartStatus = activeStatus.ToString()!
           
        };

        await unitOfWork.CartRepository.CreateAsync(newCart, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);

        return newCart.Id;
    }
}
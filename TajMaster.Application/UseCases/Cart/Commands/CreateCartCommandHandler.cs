using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Enums;

namespace TajMaster.Application.UseCases.Cart.Commands;

public class CreateCartCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCartCommand, int>
{
    public async Task<int> Handle(CreateCartCommand command, CancellationToken cancellationToken)
    {
        var newCart = new Domain.Entities.Cart
        {
            UserId = command.UserId,
            CartStatus = CartStatus.active
        };

        await unitOfWork.CartRepository.CreateAsync(newCart, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);

        return newCart.Id;
    }

}

using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Cart.CartDtos;
using TajMaster.Application.UseCases.CartExtensions;

namespace TajMaster.Application.UseCases.Cart.Queries;

public class GetCartByUserIdQueryHandler(IUnitOfWork unitOfWork) 
    : IRequestHandler<GetCartByUserIdQuery, CartDto>
{
    public async Task<CartDto> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
    {
        var cart = await unitOfWork.CartRepository.GetCartByUserIdAsync(request.UserId);

        if (cart == null)
            throw new NotFoundException($"Cart for user ID {request.UserId} not found.");

        return cart.ToCartDto();
    }
}
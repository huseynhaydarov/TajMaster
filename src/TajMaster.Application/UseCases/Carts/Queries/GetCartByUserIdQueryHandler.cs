using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Carts.CartDtos;
using TajMaster.Application.UseCases.Carts.CartExtensions;

namespace TajMaster.Application.UseCases.Carts.Queries;

public class GetCartByUserIdQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetCartByUserIdQuery, CartDto>
{
    public async Task<CartDto> Handle(GetCartByUserIdQuery request, CancellationToken cancellationToken)
    {
        var cart = await context.Carts
            .Include(c => c.User)
            .Include(c => c.CartStatus)
            .Include(c => c.CartItems)
            .ThenInclude(s => s.Service)
            .AsSplitQuery()
            .FirstOrDefaultAsync(c => c.UserId == request.UserId, cancellationToken);

        if (cart == null)
        {
            throw new NotFoundException($"Cart for user ID {request.UserId} not found.");
        }

        return cart.ToCartDto();
    }
}
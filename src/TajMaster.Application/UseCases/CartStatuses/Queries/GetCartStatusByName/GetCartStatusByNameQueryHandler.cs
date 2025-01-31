using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.CartStatuses.CartStatusDtos;

namespace TajMaster.Application.UseCases.CartStatuses.Queries.GetCartStatusByName;

public class GetCartStatusByNameQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetCartStatusByNameQuery, CartStatusDto>
{
    public async Task<CartStatusDto> Handle(GetCartStatusByNameQuery request, CancellationToken cancellationToken)
    {
        var cartStatus = await context.CartStatuses
            .AsNoTracking()
            .FirstOrDefaultAsync(cs => cs.Name == request.Name, cancellationToken);

        if(cartStatus is null)
        {
            throw new NotFoundException("CartStatus master not found");
        }
        
        return new CartStatusDto(
            StatusId: cartStatus.Id,
            Name: cartStatus.Name,
            Code: cartStatus.Code);
    }
}
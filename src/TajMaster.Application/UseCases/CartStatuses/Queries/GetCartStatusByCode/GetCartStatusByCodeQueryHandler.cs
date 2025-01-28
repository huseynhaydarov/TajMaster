using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.CartStatuses.CartStatusDtos;

namespace TajMaster.Application.UseCases.CartStatuses.Queries.GetCartStatusByCode;

public class GetCartStatusByCodeQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetCartStatusByCodeQuery, CartStatusDto>
{
    public async Task<CartStatusDto> Handle(GetCartStatusByCodeQuery request, CancellationToken cancellationToken)
    {
        var cartStatus = await context.CartStatuses
            .AsNoTracking()
            .FirstOrDefaultAsync(cs => cs.Code == request.Code, cancellationToken);

        return (cartStatus == null
            ? null
            : new CartStatusDto(cartStatus.Id, cartStatus.Name, cartStatus.Code))!;
    }
}
using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;
using TajMaster.Application.UseCases.Craftsmen.CraftsmenExtension;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmanByUser;

public class GetCraftsmanByUserIdQueryHandler(
    IApplicationDbContext context)
    : IQueryHandler<GetCraftsmanByUserIdQuery, CraftsmanDto>
{
    public async Task<CraftsmanDto> Handle(GetCraftsmanByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        var craftsman = await context.Craftsmen
            .Include(cr => cr.User)
            .Include(cr => cr.Specialization)
            .FirstOrDefaultAsync(cr => cr.UserId == request.UserId, cancellationToken);

        if (craftsman == null)
        {
            throw new NotFoundException($"No craftsman found for user with ID: {request.UserId}");
        }

        return craftsman.MapToCraftsmanDto();
    }
}
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.IdentityService;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDtos;
using TajMaster.Application.UseCases.Craftsmen.CraftsmenExtension;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmanByUser;

public class GetCraftsmanByUserQueryHandler(
    IApplicationDbContext context,
    IAuthenticatedUserService authenticatedUserService)
    : IQueryHandler<GetCraftsmanByUserQuery, CraftsmanDto>
{
    public async Task<CraftsmanDto> Handle(GetCraftsmanByUserQuery request,
        CancellationToken cancellationToken)
    {
        var craftsman = await context.Craftsmen
            .Include(cr => cr.User)
            .Include(cr => cr.Specialization)
            .AsSplitQuery()
            .FirstOrDefaultAsync(cr => cr.UserId == authenticatedUserService.UserId, cancellationToken);

        if (craftsman == null)
        {
            throw new NotFoundException($"No craftsman found for user with ID: {authenticatedUserService.UserId}");
        }

        return craftsman.MapToCraftsmanDto();
    }
}
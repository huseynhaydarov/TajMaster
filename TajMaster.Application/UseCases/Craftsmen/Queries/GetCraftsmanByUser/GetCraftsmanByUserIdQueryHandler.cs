using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmanByUser;

public class GetCraftsmanByUserIdQueryHandler(
    IApplicationDbContext context)
    : IRequestHandler<GetCraftsmanByUserIdQuery, IEnumerable<CraftsmanDto>>
{
    public async Task<IEnumerable<CraftsmanDto>> Handle(GetCraftsmanByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        var craftsmen = await context.Craftsmen
            .Include(cr => cr.User)
            .Where(cr => cr.UserId == request.UserId)
            .ToListAsync(cancellationToken);

        if (!craftsmen.Any()) throw new NotFoundException($"No craftsmen found for user with ID: {request.UserId}");

        return craftsmen.Select(craftsman => new CraftsmanDto(
            craftsman.Id,
            craftsman.Specialization.ToString() ?? string.Empty,
            craftsman.Experience,
            craftsman.Rating,
            craftsman.Description,
            craftsman.ProfilePicture,
            craftsman.IsAvialable,
            craftsman.ProfileVerified
        )).ToList();
    }
}
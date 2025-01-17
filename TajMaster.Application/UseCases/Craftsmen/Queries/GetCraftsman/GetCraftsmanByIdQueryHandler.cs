using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsman;

public class GetCraftsmanByIdQueryHandler(
    IApplicationDbContext context) 
    : IRequestHandler<GetCraftsmanByIdQuery, Craftsman>
{
    public async Task<Craftsman> Handle(GetCraftsmanByIdQuery query, CancellationToken cancellationToken)
    {
        var craftsman = await context.Craftsmen
            .FirstOrDefaultAsync(cr => cr.Id == query.CraftsmanId, cancellationToken);

        if (craftsman == null)
        {
            throw new NotFoundException($"Craftsman with ID {query.CraftsmanId} not found.");
        }

        return craftsman;
    }
}
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsman;

public class GetCraftsmanByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCraftsmanByIdQuery, Craftsman>
{
    public async Task<Craftsman> Handle(GetCraftsmanByIdQuery request, CancellationToken cancellationToken)
    {
        var craftsman = await unitOfWork.CraftsmanRepository.GetByIdAsync(request.CraftsmanId, cancellationToken);

        if (craftsman == null)
            throw new NotFoundException($"Craftsman with ID {request.CraftsmanId} not found.");
        
        return craftsman;
    }
}
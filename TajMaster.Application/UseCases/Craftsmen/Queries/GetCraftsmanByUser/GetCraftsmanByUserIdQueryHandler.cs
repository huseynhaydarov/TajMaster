using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmanByUser;

public class GetCraftsmanByUserIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetCraftsmanByUserIdQuery, IEnumerable<CraftsmanDto>>
{
    public async Task<IEnumerable<CraftsmanDto>> Handle(GetCraftsmanByUserIdQuery request, CancellationToken cancellationToken)
    {
        var craftsmen = await unitOfWork.CraftsmanRepository.GetCraftsmanByUserIdAsNoTrackingAsync(request.UserId, cancellationToken);

        var enumerable = craftsmen as Craftsman[] ?? craftsmen.ToArray();
        if (craftsmen == null || !enumerable.Any())
            throw new NotFoundException($"No craftsman found for user with ID: {request.UserId}");
        
        return enumerable.Select(craftsman => new CraftsmanDto(
                craftsman.Id,
                craftsman.Specialization.ToString(),
                craftsman.Experience,
                craftsman.Rating,
                craftsman.Description,
                craftsman.ProfilePicture,
                craftsman.IsAvialable,
                craftsman.ProfileVerified
            )).ToList();
    }
}
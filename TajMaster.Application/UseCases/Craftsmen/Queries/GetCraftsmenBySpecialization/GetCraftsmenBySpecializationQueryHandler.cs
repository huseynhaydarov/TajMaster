using AutoMapper;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.DTO;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmenBySpecialization;

public class GetCraftsmenBySpecializationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : IQueryHandler<GetCraftsmenBySpecializationQuery, List<CraftsmanDto>>
{
    public async Task<List<CraftsmanDto>> Handle(GetCraftsmenBySpecializationQuery request, CancellationToken cancellationToken)
    {
        var craftsmen = await unitOfWork.CraftsmanRepository.GetBySpecializationAsync(request.Specialization, cancellationToken);
        
        return mapper.Map<List<CraftsmanDto>>(craftsmen);
    }
}
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;
using TajMaster.Application.UseCases.Craftsmen.CraftsmenExtension;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmenBySpecialization;

public class GetCraftsmenBySpecializationQueryHandler(IUnitOfWork unitOfWork)
    : IQueryHandler<GetCraftsmenBySpecializationQuery, List<CraftsmanDto>>
{
    public async Task<List<CraftsmanDto>> Handle(GetCraftsmenBySpecializationQuery request,
        CancellationToken cancellationToken)
    {
        var craftsmen =
            await unitOfWork.CraftsmanRepository.GetBySpecializationAsync(request.Specialization, cancellationToken);

        return craftsmen.CraftsmanDtos().ToList();
    }
}
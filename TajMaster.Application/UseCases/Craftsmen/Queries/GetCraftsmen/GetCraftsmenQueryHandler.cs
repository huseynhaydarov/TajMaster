using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.DTO;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmen;

public class GetCraftsmenQueryHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetCraftsmenQuery, PaginatedResult<CraftsmanDto>>
{
    public async Task<PaginatedResult<CraftsmanDto>> Handle(GetCraftsmenQuery request, CancellationToken cancellationToken)
    {
        var pagingParams = request.PagingParameters;

        var paginatedCraftsmen = await unitOfWork.CraftsmanRepository.GetAllAsync(pagingParams, cancellationToken);

        var totalCount = paginatedCraftsmen.Count();

        var craftsmanDto = paginatedCraftsmen
            .Select(craftsman => new CraftsmanDto(
                craftsman.Id,
                craftsman.Specialization.ToString(),
                craftsman.Experience,
                craftsman.Rating,
                craftsman.Description,
                craftsman.ProfilePicture,
                craftsman.IsAvialable,
                craftsman.ProfileVerified
            )).ToList();
       
        var paginatedResult =  new PaginatedResult<CraftsmanDto>(
            pagingParams.PageNumber!.Value,
            pagingParams.PageSize!.Value,
            totalCount,
            craftsmanDto
        );
        return paginatedResult;
    }
}
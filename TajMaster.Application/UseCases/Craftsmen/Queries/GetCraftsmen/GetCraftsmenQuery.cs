using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmen;

public record GetCraftsmenQuery(PagingParameters PagingParameters) : IQuery<PaginatedResult<CraftsmanDto>>;
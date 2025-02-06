using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDtos;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmen;

public record GetCraftsmenQuery(PagingParameters PagingParameters) : IQuery<PaginatedResult<CraftsmanDto>>;
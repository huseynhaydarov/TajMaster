using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.DTO;

namespace TajMaster.Application.UseCases.Services.Queries;

public record GetServicesQuery(PagingParameters PagingParameters) : IQuery<PaginatedResult<ServiceDto>>;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Pagination;
using TajMaster.Application.UseCases.DTOs;
using TajMaster.Application.UseCases.Services.ServiceDtos;

namespace TajMaster.Application.UseCases.Services.Queries.GetServices;

public record GetServicesQuery(PagingParameters PagingParameters) : IQuery<PaginatedResult<ServiceDto>>;
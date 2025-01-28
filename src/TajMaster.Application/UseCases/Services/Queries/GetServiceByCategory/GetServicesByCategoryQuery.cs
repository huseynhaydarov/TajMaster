using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Services.ServiceDtos;

namespace TajMaster.Application.UseCases.Services.Queries.GetServiceByCategory;

public record GetServicesByCategoryQuery(Guid CategoryId) : IQuery<IEnumerable<ServiceSummaryDto>>;
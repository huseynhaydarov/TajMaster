using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.DTO;

namespace TajMaster.Application.UseCases.Services.Queries.GetServiceByCategory;

public record GetServicesByCategoryQuery(int CategoryId) : IQuery<IEnumerable<ServiceDto>>;
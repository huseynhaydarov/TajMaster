using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Services.ServiceDtos;

namespace TajMaster.Application.UseCases.Services.Queries.GetService;

public record GetServiceByIdQuery(Guid ServiceId) : IQuery<ServiceDetailDto>;
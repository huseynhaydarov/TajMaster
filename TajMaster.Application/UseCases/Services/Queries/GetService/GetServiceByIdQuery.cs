using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Services.ServiceDtos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Services.Queries.GetService;

public record GetServiceByIdQuery(int ServiceId) : IQuery<ServiceDto>;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.DTO;
using TajMaster.Application.UseCases.DTOs;
using TajMaster.Application.UseCases.Services.ServiceDtos;

namespace TajMaster.Application.UseCases.Services.Queries.GetServiceByCategory;

public record GetServicesByCategoryQuery(int CategoryId) : IQuery<IEnumerable<ServiceDto>>;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Specializations.SpecializationDtos;

namespace TajMaster.Application.UseCases.Specializations.Queries.GetById;

public record GetSpecializationByIdQuery(Guid SpecializationId) : IQuery<SpecializationDto>;
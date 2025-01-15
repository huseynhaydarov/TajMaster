using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Specializations.SpecializationDtos;

namespace TajMaster.Application.UseCases.Specializations.Queries.GetAll;

public record GetAllSpecializationsQuery() : IQuery<List<SpecializationDto>>;
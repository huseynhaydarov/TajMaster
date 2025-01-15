using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Specializations.SpecializationDtos;
using TajMaster.Application.UseCases.Users.UserDtos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Specializations.Queries.GetById;

public record GetSpecializationByIdQuery(Guid SpecializationId) : IQuery<SpecializationDto>;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.DTO;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmenBySpecialization;

public record GetCraftsmenBySpecializationQuery(string Specialization) : IQuery<List<CraftsmanDto>>;
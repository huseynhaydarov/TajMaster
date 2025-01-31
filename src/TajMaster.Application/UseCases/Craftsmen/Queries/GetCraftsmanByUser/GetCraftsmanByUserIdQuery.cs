using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDtos;


namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmanByUser;

public record GetCraftsmanByUserIdQuery(Guid UserId) : IQuery<CraftsmanDto>;
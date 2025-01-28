using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsmanByUser;

public record GetCraftsmanByUserIdQuery(Guid UserId) : IQuery<CraftsmanDto>;
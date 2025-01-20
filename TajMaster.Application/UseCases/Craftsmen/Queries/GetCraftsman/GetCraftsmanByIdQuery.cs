using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Craftsmen.CraftsmanDTos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsman;

public record GetCraftsmanByIdQuery(Guid CraftsmanId) : IQuery<CraftsmanDto>;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Craftsmen.Queries.GetCraftsman;

public record GetCraftsmanByIdQuery(Guid CraftsmanId) : IQuery<Craftsman>;
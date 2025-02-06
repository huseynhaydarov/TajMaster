using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.CartStatuses.CartStatusDtos;

namespace TajMaster.Application.UseCases.CartStatuses.Queries.GetCartStatusByName;

public record GetCartStatusByNameQuery(string Name) : IQuery<CartStatusDto>;
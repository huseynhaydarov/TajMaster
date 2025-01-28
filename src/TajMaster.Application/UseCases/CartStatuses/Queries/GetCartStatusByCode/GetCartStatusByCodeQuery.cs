using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.CartStatuses.CartStatusDtos;

namespace TajMaster.Application.UseCases.CartStatuses.Queries.GetCartStatusByCode;

public record GetCartStatusByCodeQuery(string Code) : IQuery<CartStatusDto>;
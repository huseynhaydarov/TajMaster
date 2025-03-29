using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Carts.CartDtos;

namespace TajMaster.Application.UseCases.Carts.Queries;

public record GetCartByUserQuery : IQuery<CartDto>;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Cart.CartDtos;

namespace TajMaster.Application.UseCases.Cart.Queries;

public record GetCartByUserIdQuery(int UserId) : IQuery<CartDto>;
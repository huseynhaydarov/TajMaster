using Carter;
using MediatR;
using TajMaster.Application.UseCases.Orders.OrderDtos;
using TajMaster.Application.UseCases.Orders.Queries.GetOrdersByUser;

namespace TajMaster.WebApi.Endpoints.Orders;

public class GetOrdersByUserIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/orders/user/{userId:guid}", async (Guid userId, ISender sender) =>
            {
                if (userId == Guid.Empty)
                {
                    return Results.BadRequest(new { Message = "Invalid user ID." });
                }
                
                var query = new GetOrdersByUserIdQuery(userId);
                
                var orders = await sender.Send(query);
                
                var orderDto = orders as OrderDetailDto[] ?? orders.ToArray();

                if (!orderDto.Any())
                {
                    return Results.NotFound(new { Message = $"No orders found for user ID {userId}." });
                }
                
                return Results.Ok(orderDto);
            })
            .WithName("GetOrdersByUserEndpoint")
            .WithTags("Orders")
            .Produces<IEnumerable<OrderDetailDto>>();

    }
}
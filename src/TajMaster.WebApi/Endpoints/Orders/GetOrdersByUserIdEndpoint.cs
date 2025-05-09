using Carter;
using MediatR;
using TajMaster.Application.UseCases.Orders.OrderDtos;
using TajMaster.Application.UseCases.Orders.Queries.GetOrdersByUser;

namespace TajMaster.WebApi.Endpoints.Orders;

public class GetOrdersByUserIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/orders/user/{userId:guid}", async (Guid userId, 
                ISender sender, CancellationToken cancellationToken) =>
            {
                if (userId == Guid.Empty)
                {
                    return Results.BadRequest();
                }
                
                var query = new GetOrdersByUserQuery();
                
                var orders = await sender.Send(query, cancellationToken);
                
                var orderDto = orders as OrderDetailDto[] ?? orders.ToArray();

                if (!orderDto.Any())
                {
                    return Results.NotFound();
                }
                
                return Results.Ok(orderDto);
            })
            .RequireAuthorization("AdminOrCustomerPolicy")
            .WithName("GetOrdersByUserEndpoint")
            .WithTags("Orders")
            .Produces<IEnumerable<OrderDetailDto>>();

    }
}
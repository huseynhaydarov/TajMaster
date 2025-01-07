using TajMaster.Application.UseCases.OrderItems;
using TajMaster.Application.UseCases.Orders.OrderDtos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Orders.OrderExtensions;

public static class OrderMappingExtensions
{

    public static IEnumerable<OrderSummaryDto> ToOrderSummaryDtoList(this IEnumerable<Order> orders)
    {
        return orders.Select(order => order.ToOrderSummaryDto());
    }

    private static OrderSummaryDto ToOrderSummaryDto(this Order order)
    {
        return new OrderSummaryDto(
            OrderId: order.Id,
            UserId: order.UserId,
            CraftsmanId: order.CraftsmanId,
            AppointmentDate: order.AppointmentDate,
            Address: order.Address,
            OrderStatus: order.Status.ToString(),
            TotalPrice: order.TotalPrice
        );
    }
    
    public static OrderDetailDto MapToOrder(this Order order)
    {
        return new OrderDetailDto(
            OrderId: order.Id,
            UserId: order.UserId,
            CraftsmanId: order.CraftsmanId,
            AppointmentDate: order.AppointmentDate,
            Address: order.Address,
            OrderStatus: order.Status.ToString(),
            TotalPrice: order.TotalPrice,
            OrderItems: order.OrderItems.Select(oi => new OrderItemDto(
                OrderId: oi.OrderId,
                ServiceId: oi.ServiceId,
                Quantity: oi.Quantity,
                Price: oi.Price
            )).ToList()
        );
    }
}
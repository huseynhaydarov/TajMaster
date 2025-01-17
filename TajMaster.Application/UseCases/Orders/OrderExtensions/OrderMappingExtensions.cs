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

    public static IEnumerable<OrderDetailDto> ToOrderDetailDtoList(this IEnumerable<Order> orders)
    {
        return orders.Select(order => order.MapToOrder());
    }

    public static OrderDetailDto MapToOrder(this Order order)
    {
        return new OrderDetailDto(
            order.Id,
            order.UserId,
            order.CraftsmanId,
            order.AppointmentDate,
            order.Address,
            order.OrderStatus.Name,
            order.TotalPrice,
            order.OrderItems.Select(oi => new OrderItemDto(
                oi.OrderId,
                oi.ServiceId,
                oi.Quantity,
                oi.Price
            )).ToList()
        );
    }

    private static OrderSummaryDto ToOrderSummaryDto(this Order order)
    {
        return new OrderSummaryDto(
            order.Id,
            order.UserId,
            order.CraftsmanId,
            order.AppointmentDate,
            order.Address,
            order.OrderStatus.Name,
            order.TotalPrice
        );
    }
}
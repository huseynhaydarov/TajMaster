using AutoMapper;
using TajMaster.Application.UseCases.Orders.Commands.Update;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.OrderStatuses.OrderStatusMappings;

public class UpdateOrderStatusMapper : Profile
{
    public UpdateOrderStatusMapper()
    {
        CreateMap<UpdateOrderStatusCommand, Order>();
    }
}
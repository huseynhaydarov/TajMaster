using AutoMapper;
using TajMaster.Application.UseCases.OrderStatuses.Commands.Create;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.OrderStatuses.OrderStatusMappings;

public class CreateOrderStatusMapper : Profile
{
    public CreateOrderStatusMapper()
    {
        CreateMap<CreateOrderStatusCommand, OrderStatus>();
    }
}
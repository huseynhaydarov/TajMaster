using AutoMapper;
using TajMaster.Application.UseCases.Orders.Commands.Create;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Orders.OrderMappings;

public class CreateOrderMapper : Profile
{
    public CreateOrderMapper()
    {
        CreateMap<CreateOrderCommand, Order>();
    }
}
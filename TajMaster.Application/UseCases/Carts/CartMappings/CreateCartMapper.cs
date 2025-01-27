using AutoMapper;
using TajMaster.Application.UseCases.Carts.Commands;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Carts.CartMappings;

public class CreateCartMapper : Profile
{
    public CreateCartMapper()
    {
        CreateMap<CreateCartCommand, Cart>();
    }
}
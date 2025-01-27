using AutoMapper;
using TajMaster.Application.UseCases.CartStatuses.Command.Create;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.CartStatuses.CartStatusMappings;

public class CreateCartStatusMapper : Profile
{
    public CreateCartStatusMapper()
    {
        CreateMap<CreateCartStatusCommand, CartStatus>();
    }
}
using AutoMapper;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.CartStatuses.CartStatusMappings;

public class UpdateCartStatusCommand : Profile
{
    public UpdateCartStatusCommand()
    {
        CreateMap<UpdateCartStatusCommand, CartStatus>();
    }
}
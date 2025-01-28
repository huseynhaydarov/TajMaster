using AutoMapper;
using TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateAvailability;
using TajMaster.Application.UseCases.Craftsmen.Commands.Update.UpdateCraftsman;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Craftsmen.CraftsmanMappings;

public class UpdateCraftsmanMapper : Profile
{
    public UpdateCraftsmanMapper()
    {
        CreateMap<UpdateCraftsmanCommand, Craftsman>()
            .ForPath(dest => dest.Specialization.Name, opt 
                => opt.MapFrom(src => src.Specialization));
        CreateMap<UpdateCraftsmanAvailabilityCommand, Craftsman>();

    }
}
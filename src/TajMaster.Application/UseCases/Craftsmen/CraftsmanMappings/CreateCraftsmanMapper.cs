using AutoMapper;
using TajMaster.Application.UseCases.Craftsmen.Commands.Create.CompleteCraftsmanProfile;
using TajMaster.Application.UseCases.Craftsmen.Commands.Create.CreateCraftsman;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Craftsmen.CraftsmanMappings;

public class CreateCraftsmanMapper : Profile
{
    public CreateCraftsmanMapper()
    {
        CreateMap<CreateCraftsmanCommand, User>()
            .ForMember(dest => dest.HashedPassword, opt 
                => opt.MapFrom(src => src.Password));
        
        CreateMap<CompleteCraftsmanProfileCommand, Craftsman>()
            .ForMember(c => c.Description, opt
                => opt.MapFrom(src => src.About))
            .ForMember(c => c.ProfilePicture, opt
                => opt.Ignore())
            .ForMember(c => c.Specialization, opt 
                => opt.Ignore());

    }
}
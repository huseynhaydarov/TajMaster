using AutoMapper;
using TajMaster.Application.UseCases.Services.Commands.Update;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Services.ServiceMappings;

public class UpdateServiceMapper : Profile
{
    public UpdateServiceMapper()
    {
        CreateMap<UpdateServiceCommand, Service>()
            .ForMember(dest => dest.CategoryServices, opt 
                => opt.Ignore());
    }
}
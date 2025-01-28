using AutoMapper;
using TajMaster.Application.UseCases.Services.Commands.Create;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Services.ServiceMappings;

public class CreateServiceMapper : Profile
{
   public CreateServiceMapper()
   {
      CreateMap<CreateServiceCommand, Service>()
         .ForMember(dest => dest.CategoryServices, opt 
            => opt.Ignore());
   }
}
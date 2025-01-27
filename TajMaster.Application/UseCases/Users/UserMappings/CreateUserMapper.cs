using AutoMapper;
using TajMaster.Application.UseCases.Users.Commands.Create;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Users.UserMappings;

public class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserCommand, User>()
            .ForMember(dest => dest.HashedPassword, opt 
                => opt.MapFrom(src => src.Password));
    }
}
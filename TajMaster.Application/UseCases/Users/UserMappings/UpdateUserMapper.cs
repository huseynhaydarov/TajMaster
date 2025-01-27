using AutoMapper;
using TajMaster.Application.UseCases.Users.Commands.Update;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Users.UserMappings;

public class UpdateUserMapper : Profile
{
    public UpdateUserMapper()
    {
        CreateMap<UpdateUserCommand, User>();
    }
}
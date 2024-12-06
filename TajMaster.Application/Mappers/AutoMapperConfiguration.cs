using System.Net.Http.Headers;
using AutoMapper;
using TajMaster.Application.UseCases.Users.Commands.Create;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.Mappers;

public class AutoMapperConfiguration : Profile
{
    public AutoMapperConfiguration()
    {
        CreateMap<CreateUserCommand, User>();
    }
}

using AutoMapper;
using TajMaster.Application.UseCases.Specializations.Commands.Create;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Specializations.SpecializationMappings;

public class CreateSpecializationMapper : Profile
{
    public CreateSpecializationMapper()
    {
        CreateMap<CreateSpecializationCommand, Specialization>();
    }
}
using AutoMapper;
using TajMaster.Application.UseCases.Specializations.Commands.Update;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Specializations.SpecializationMappings;

public class UpdateSpecializationMapper : Profile
{
    public UpdateSpecializationMapper()
    {
        CreateMap<UpdateSpecializationCommand, Specialization>();
    }
}
using AutoMapper;
using TajMaster.Application.UseCases.Categories.Commands.Update;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Categories.CategoryMappings;

public class UpdateCategoryMapper : Profile
{
    public UpdateCategoryMapper()
    {
        CreateMap<UpdateCategoryCommand, Category>();
    }
}
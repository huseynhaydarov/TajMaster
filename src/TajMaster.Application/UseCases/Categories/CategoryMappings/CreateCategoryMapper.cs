using AutoMapper;
using TajMaster.Application.UseCases.Categories.Commands.Create;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Categories.CategoryMappings;

public class CreateCategoryMapper : Profile
{
    public CreateCategoryMapper()
    {
        CreateMap<CreateCategoryCommand, Category>();
    }
}
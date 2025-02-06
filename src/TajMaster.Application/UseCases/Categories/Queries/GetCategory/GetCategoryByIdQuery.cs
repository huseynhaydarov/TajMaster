using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.UseCases.Categories.CategoryDtos;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Categories.Queries.GetCategory;

public record GetCategoryByIdQuery(Guid CategoryId) : IQuery<CategoryDto>;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Categories.Queries.GetCategory;

public record GetCategoryByIdQuery(int CategoryId) : IQuery<Category>;
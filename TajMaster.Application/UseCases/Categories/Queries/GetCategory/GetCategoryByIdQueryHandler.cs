using MediatR;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Categories.Queries.GetCategory;

public class GetCategoryByIdQueryHandler(IUnitOfWork unitOfWork, ILogger<GetCategoryByIdQueryHandler> logger)
    : IRequestHandler<GetCategoryByIdQuery, Category>
{
    public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

            if (category == null)
            {
                logger.LogWarning("Category with ID {CategoryId} not found.", request.CategoryId);
                return null!;
            }

            return category;
        }
        catch (NotFoundException ex)
        {
            logger.LogError(ex, "Error occurred while fetching category with ID {CategoryId}", request.CategoryId);
            throw;
        }
    }
}
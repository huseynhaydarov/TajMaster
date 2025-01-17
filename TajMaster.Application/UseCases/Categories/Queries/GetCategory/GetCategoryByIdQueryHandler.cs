using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Categories.Queries.GetCategory;

public class GetCategoryByIdQueryHandler(
    IApplicationDbContext context, 
    ILogger<GetCategoryByIdQueryHandler> logger)
    : IRequestHandler<GetCategoryByIdQuery, Category>
{
    public async Task<Category> Handle(GetCategoryByIdQuery command, CancellationToken cancellationToken)
    {
        try
        {
            var category =
                await context.Categories.FirstOrDefaultAsync(c => c.Id == command.CategoryId, cancellationToken);

            if (category == null)
            {
                logger.LogWarning("Category with ID {CategoryId} not found.", command.CategoryId);
                
                throw new NotFoundException("Category with ID " + command.CategoryId + " not found.");
            }

            return category;
        }
        catch (NotFoundException ex)
        {
            logger.LogError(ex, "Error occurred while fetching category with ID {CategoryId}", command.CategoryId);
            throw;
        }
    }
}
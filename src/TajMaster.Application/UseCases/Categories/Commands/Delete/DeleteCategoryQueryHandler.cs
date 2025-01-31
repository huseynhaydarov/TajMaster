using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Categories.Commands.Delete;

public class DeleteCategoryQueryHandler(
    IApplicationDbContext context,
    ILogger<DeleteCategoryQueryHandler> logger)
    : IRequestHandler<DeleteCategoryCommand, Unit>
{
    public async Task<Unit> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .FirstOrDefaultAsync(c => c.Id == command.CategoryId, cancellationToken);

        if (category == null)
        {
            logger.LogWarning("Category with ID {CategoryId} not found.", command.CategoryId);

            throw new NotFoundException($"Category with ID {command.CategoryId} not found");
        }

        logger.LogInformation("Deleting category with ID {CategoryId}.", command.CategoryId);

        context.Categories.Remove(category);

        await context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
       
}

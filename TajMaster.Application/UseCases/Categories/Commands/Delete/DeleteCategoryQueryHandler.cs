using MediatR;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.Data;

namespace TajMaster.Application.UseCases.Categories.Commands.Delete;

public class DeleteCategoryQueryHandler(IUnitOfWork unitOfWork, ILogger<DeleteCategoryQueryHandler> logger)
    : IRequestHandler<DeleteCategoryCommand, bool>
{
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var category = await unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

            if (category == null)
            {
                logger.LogWarning("Category with ID {CategoryId} not found.", request.CategoryId);
                return false;
            }
            
            logger.LogInformation("Deleting category with ID {CategoryId}.", request.CategoryId);
            
            await unitOfWork.CategoryRepository.DeleteAsync(category, cancellationToken);
            
            await unitOfWork.CompleteAsync(cancellationToken);
            
            return true;
        }
        catch (Exception ex)
        {
            logger.LogError($"Error retrieving book: {ex.Message}");
            throw;
        }
    }
}

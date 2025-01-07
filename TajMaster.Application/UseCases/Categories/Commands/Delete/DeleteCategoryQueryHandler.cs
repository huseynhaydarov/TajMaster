using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Categories.Commands.Delete;

public class DeleteCategoryQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCategoryCommand, bool>
{
    public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        if (category == null) 
            throw new NotFoundException($"Category with ID {request.CategoryId} not found");

        await unitOfWork.CategoryRepository.DeleteAsync(category, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}
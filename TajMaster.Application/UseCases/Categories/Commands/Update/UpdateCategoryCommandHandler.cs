using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Categories.Commands.Update;

public class UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<UpdateCategoryCommand, bool>
{
    public async Task<bool> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await unitOfWork.CategoryRepository.GetByIdAsync(command.CategoryId, cancellationToken);

        if (category == null)
            throw new NotFoundException($"Category with ID {command.CategoryId} not found.");

        mapper.Map(command, category);

        await unitOfWork.CategoryRepository.UpdateAsync(category, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        return true;
    }
}
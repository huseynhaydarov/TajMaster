using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Categories.Commands.Create;

public class CreateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper) : IRequestHandler<CreateCategoryCommand, int>
{
    public async Task<int> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = mapper.Map<Category>(command);

        category = await unitOfWork.CategoryRepository.CreateAsync(category, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        return category.Id;
    }
}
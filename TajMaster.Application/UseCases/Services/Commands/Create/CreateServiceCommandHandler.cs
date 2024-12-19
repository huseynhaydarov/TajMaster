using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.UseCases.Users.Exceptions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Services.Commands.Create;

public class CreateServiceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateServiceCommand, int>
{
    public async Task<int> Handle(CreateServiceCommand command, CancellationToken cancellationToken)
    {
        var categoryList = await unitOfWork.CategoryRepository.GetGetByIdsAsync(command.Categories, cancellationToken);

        if (categoryList == null || categoryList.Count != command.Categories.Count)
            throw new ServiceNotFoundException(nameof(Category));

        var service = mapper.Map<Service>(command);

        service.Categories = categoryList.ToList();

        service = await unitOfWork.ServiceRepository.CreateAsync(service, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        return service.Id;
    }
}
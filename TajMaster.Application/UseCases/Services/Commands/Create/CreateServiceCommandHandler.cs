using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Services.Commands.Create;

public class CreateServiceCommandHandler(
    IApplicationDbContext context,
    IMapper mapper)
    : IRequestHandler<CreateServiceCommand, Guid>
{
    public async Task<Guid> Handle(CreateServiceCommand command, CancellationToken cancellationToken)
    {
        var categoryIds = command.Categories;
        var categories = await context.Categories
            .Where(c => categoryIds.Contains(c.Id))
            .ToListAsync(cancellationToken);

        if (categories.Count != categoryIds.Count)
        {
            throw new NotFoundException(nameof(Category));
        }

        var service = mapper.Map<Service>(command);

        service.CategoryServices = categories.Select(category => new CategoryService
        {
            CategoryId = category.Id,
        }).ToList();

        context.Services.Add(service);

        await context.SaveChangesAsync(cancellationToken);

        return service.Id;
    }
}
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Services.Commands.Create;

public class CreateServiceCommandHandler(
    IApplicationDbContext context,
    IMapper mapper,
    IDistributedCache cache,
    ILogger<CreateServiceCommandHandler> logger)
    : ICommandHandler<CreateServiceCommand, Guid>
{
    public async Task<Guid> Handle(CreateServiceCommand command, CancellationToken cancellationToken)
    {
        var categoryIds = command.Categories;
        var categories = await context.Categories
            .Where(c => categoryIds.Contains(c.Id))
            .ToListAsync(cancellationToken);

        if (categories.Count != categoryIds.Count)
        {
            throw new NotFoundException("One or more categories not found.");
        }
        
        var service = mapper.Map<Service>(command);
        service.CategoryServices = categories.Select(category => new CategoryService
        {
            CategoryId = category.Id,
        }).ToList();

        context.Services.Add(service);
        await context.SaveChangesAsync(cancellationToken);

        var cacheKey = "services";
        logger.LogInformation("Invalidating cache for key: {CacheKey}", cacheKey);
        await cache.RemoveAsync(cacheKey, cancellationToken);

        return service.Id;
    }
}
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Categories.Commands.Update;

public class UpdateCategoryCommandHandler(
    IApplicationDbContext context, 
    IMapper mapper)
    : IRequestHandler<UpdateCategoryCommand, bool>
{
    public async Task<bool> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = await context.Categories
            .FirstOrDefaultAsync(c => c.Id == command.CategoryId, cancellationToken);

        if (category == null)
        {
            throw new NotFoundException($"Category with ID {command.CategoryId} not found.");
        }

        mapper.Map(command, category);

        context.Categories.Update(category);

        await context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}
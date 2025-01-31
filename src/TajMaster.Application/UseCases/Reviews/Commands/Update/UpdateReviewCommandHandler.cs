using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Reviews.Commands.Update;

public class UpdateReviewCommandHandler(
    IApplicationDbContext context,
    IMapper mapper)
    : ICommandHandler<UpdateReviewCommand, Unit>
{
    public async Task<Unit> Handle(UpdateReviewCommand command, CancellationToken cancellationToken)
    {
        var review = await context.Reviews.FirstOrDefaultAsync(r => r.Id == command.ReviewId, cancellationToken);

        if (review == null)
        {
            throw new NotFoundException($"Review with ID: {command.ReviewId} not found");
        }

        mapper.Map(command, review);

        context.Reviews.Update(review);

        await context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}
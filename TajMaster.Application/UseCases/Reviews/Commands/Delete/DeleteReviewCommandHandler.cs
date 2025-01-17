using MediatR;
using Microsoft.EntityFrameworkCore;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Reviews.Commands.Delete;

public class DeleteReviewCommandHandler(
    IApplicationDbContext context) 
    : IRequestHandler<DeleteReviewCommand, bool>
{
    public async Task<bool> Handle(DeleteReviewCommand command, CancellationToken cancellationToken)
    {
        var review = await context.Reviews
            .FirstOrDefaultAsync(r => r.Id == command.ReviewId, cancellationToken);

        if (review == null)
        {
            throw new NotFoundException($"Review with ID {command.ReviewId} not found");
        }

        context.Reviews.Remove(review);

        await context.SaveChangesAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}
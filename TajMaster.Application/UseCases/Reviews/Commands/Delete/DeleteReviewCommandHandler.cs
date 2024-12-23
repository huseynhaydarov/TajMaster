using MediatR;
using TajMaster.Application.Common.Interfaces.Data;

namespace TajMaster.Application.UseCases.Reviews.Commands.Delete;

public class DeleteReviewCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteReviewCommand, bool>
{
    public async Task<bool> Handle(DeleteReviewCommand command, CancellationToken cancellationToken)
    {
        var review = await unitOfWork.UserRepository.GetByIdAsync(command.ReviewId, cancellationToken);

        if (review == null) return await Task.FromResult(false);

        await unitOfWork.UserRepository.DeleteAsync(review, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}
using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;

namespace TajMaster.Application.UseCases.Reviews.Commands.Update;

public class UpdateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateReviewCommand, bool>
{
    public async Task<bool> Handle(UpdateReviewCommand command, CancellationToken cancellationToken)
    {
        var review = await unitOfWork.ReviewRepository.GetByIdAsync(command.ReviewId, cancellationToken);

        if (review == null)
            throw new NotFoundException($"Review with ID: {command.ReviewId} not found");

        mapper.Map(command, review);

        await unitOfWork.ReviewRepository.UpdateAsync(review, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        return true;
    }
}
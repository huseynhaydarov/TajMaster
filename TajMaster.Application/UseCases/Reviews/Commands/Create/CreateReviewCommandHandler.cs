using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Reviews.Commands.Create;

public class CreateReviewCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateReviewCommand, Guid>
{
    public async Task<Guid> Handle(CreateReviewCommand command, CancellationToken cancellationToken)
    {
        var review = mapper.Map<Review>(command);

        review = await unitOfWork.ReviewRepository.CreateAsync(review, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        return review.Id;
    }
}
using AutoMapper;
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Reviews.Commands.Create;

public class CreateReviewCommandHandler(
    IApplicationDbContext context, 
    IMapper mapper)
    : IRequestHandler<CreateReviewCommand, Guid>
{
    public async Task<Guid> Handle(CreateReviewCommand command, CancellationToken cancellationToken)
    {
        var review = mapper.Map<Review>(command);

        context.Reviews.Add(review);
        
        await context.SaveChangesAsync(cancellationToken);

        return review.Id;
    }
}
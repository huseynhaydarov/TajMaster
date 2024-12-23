using MediatR;

namespace TajMaster.Application.UseCases.Reviews.Commands.Update;

public record UpdateReviewCommand(
    int ReviewId,
    int Rating,
    string Comment) 
    : IRequest<bool>; 
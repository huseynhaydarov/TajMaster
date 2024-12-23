using MediatR;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.Reviews.Commands.Create;

public record CreateReviewCommand(
    int OrderId,
    int UserId,
    int CraftsmanId,
    int Rating,
    string Comment,
    DateTime ReviewDate) 
    : ICommand<int>;
   

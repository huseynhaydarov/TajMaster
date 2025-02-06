using MediatR;

namespace TajMaster.Application.Common.Interfaces.CQRS;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
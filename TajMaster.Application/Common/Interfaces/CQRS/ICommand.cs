using MediatR;

namespace TajMaster.Application.Common.Interfaces.CQRS;

public interface ICommand : ICommand<Unit>
{
}

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}
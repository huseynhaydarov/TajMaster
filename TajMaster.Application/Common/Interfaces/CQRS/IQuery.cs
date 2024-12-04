using MediatR;

namespace TajMaster.Application.Common.Interfaces.CQRS;

public interface IQuery<out TResponse> : IRequest<TResponse>
where TResponse : notnull
{
}
using MediatR;
using TajMaster.Application.Common.Interfaces.Data;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Delete;

public class DeleteCraftsmanCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteCraftsmanCommand, bool>
{
    public async Task<bool> Handle(DeleteCraftsmanCommand request, CancellationToken cancellationToken)
    {
        var craftsman = await unitOfWork.CraftsmanRepository.GetByIdAsync(request.CraftsmanId, cancellationToken);

        if (craftsman == null) return await Task.FromResult(false);

        await unitOfWork.CraftsmanRepository.DeleteAsync(craftsman, cancellationToken);

        await unitOfWork.CompleteAsync(cancellationToken);

        return await Task.FromResult(true);
    }
}
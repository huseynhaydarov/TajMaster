using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Services.Commands.Create;

public record CreateServiceCommand(
    string Title,
    string Description,
    decimal BasePrice,
    int CraftsmanId,
    IList<int> Categories)
    : ICommand<int>;
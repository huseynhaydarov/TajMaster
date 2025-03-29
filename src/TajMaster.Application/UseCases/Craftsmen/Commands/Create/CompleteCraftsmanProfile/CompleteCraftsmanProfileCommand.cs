using Microsoft.AspNetCore.Http;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Create.CompleteCraftsmanProfile;

public record CompleteCraftsmanProfileCommand(
    string Specialization,
    int Experience,
    string? About,
    IFormFile? ProfilePicture
) : ICommand<Guid>;
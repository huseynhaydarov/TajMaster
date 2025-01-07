using Microsoft.AspNetCore.Http;
using TajMaster.Application.Common.Interfaces.CQRS;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Create;

public record CreateCraftsmanCommand(
    int UserId, 
    int Specialization, 
    int Experience, 
    string? About, 
    IFormFile? ProfilePicture
) : ICommand<int>;
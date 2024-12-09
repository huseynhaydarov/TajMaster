using TajMaster.Domain.Entities;

namespace TajMaster.Application.UseCases.DTO;

public record CategoryDto(
    int CategoryId,
    string Name,
    string Description,
    List<Service> Services);

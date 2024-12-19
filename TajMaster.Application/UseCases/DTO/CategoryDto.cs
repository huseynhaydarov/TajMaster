namespace TajMaster.Application.UseCases.DTO;

public record CategoryDto(
    int CategoryId,
    string Name,
    string Description,
    List<ServiceDto> Services);
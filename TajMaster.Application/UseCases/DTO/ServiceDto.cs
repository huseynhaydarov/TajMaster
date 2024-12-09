namespace TajMaster.Application.UseCases.DTO;

public record ServiceDto(
    int ServiceId,
    string Title,
    string Description,
    decimal BasePrice,
    List<CategoryDto> Categories);
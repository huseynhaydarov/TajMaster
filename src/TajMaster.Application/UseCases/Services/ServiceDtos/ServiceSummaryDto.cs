namespace TajMaster.Application.UseCases.Services.ServiceDtos;

public record ServiceSummaryDto(
    Guid ServiceId,
    string Title,
    string Description,
    decimal BasePrice);
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.BlobStorage;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Create;

public class CreateCraftsmanCommandHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IBlobService blobService,
    ILogger<CreateCraftsmanCommandHandler> logger)
    : IRequestHandler<CreateCraftsmanCommand, int>
{
    public async Task<int> Handle(CreateCraftsmanCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting to process CreateCraftsmanCommand for UserId: {UserId}", command.UserId);

        var user = await unitOfWork.UserRepository.GetByIdAsync(command.UserId, cancellationToken);
        if (user == null)
            throw new NotFoundException("User not found.");

        if (user.Roles != Role.Craftsman)
            throw new InvalidOperationException("The user is not eligible to become a craftsman.");

        string? profilePictureUrl = null;

        if (command.ProfilePicture != null)
        {
            logger.LogInformation(
                "Processing profile picture. Filename: {FileName}, Content Type: {ContentType}, Length: {Length} bytes",
                command.ProfilePicture.FileName,
                command.ProfilePicture.ContentType,
                command.ProfilePicture.Length);

            try
            {
                profilePictureUrl = await blobService.UploadFileAsync(command.ProfilePicture, "images");
                logger.LogInformation("Successfully uploaded profile picture. URL: {Url}", profilePictureUrl);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to upload profile picture for user {UserId}", command.UserId);
                throw;
            }
        }
        else
        {
            logger.LogWarning("No profile picture provided for user {UserId}", command.UserId);
        }

        var craftsman = mapper.Map<Craftsman>(command);
        craftsman.UserId = command.UserId;
        craftsman.ProfilePicture = profilePictureUrl;

        craftsman = await unitOfWork.CraftsmanRepository.CreateAsync(craftsman, cancellationToken);
        await unitOfWork.CompleteAsync(cancellationToken);

        logger.LogInformation("Successfully created craftsman with ID: {CraftsmanId}", craftsman.Id);

        return craftsman.Id;
    }
}
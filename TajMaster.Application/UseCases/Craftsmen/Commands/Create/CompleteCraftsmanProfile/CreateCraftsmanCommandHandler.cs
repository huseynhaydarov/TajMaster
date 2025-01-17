using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.BlobStorage;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Create.CompleteCraftsmanProfile;

public class CreateCraftsmanCommandHandler(
    IApplicationDbContext context,
    IMapper mapper,
    IBlobService blobService,
    ILogger<CreateCraftsmanCommandHandler> logger)
    : IRequestHandler<CompleteCraftsmanProfileCommand, Guid>
{
    public async Task<Guid> Handle(CompleteCraftsmanProfileCommand profileCommand, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting to process CreateCraftsmanCommand for UserId: {UserId}", profileCommand.UserId);

        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == profileCommand.UserId, cancellationToken);
        
        if (user == null)
        {
            throw new NotFoundException($"User with Id {profileCommand.UserId} not found.");
        }

        if (user.Roles != Role.Craftsman)
            throw new InvalidOperationException("The user is not eligible to become a craftsman.");

        string? profilePictureUrl = null;

        if (profileCommand.ProfilePicture != null)
        {
            logger.LogInformation(
                "Processing profile picture. Filename: {FileName}, Content Type: {ContentType}, Length: {Length} bytes",
                profileCommand.ProfilePicture.FileName,
                profileCommand.ProfilePicture.ContentType,
                profileCommand.ProfilePicture.Length);

            try
            {
                profilePictureUrl = await blobService.UploadFileAsync(profileCommand.ProfilePicture, "images");
                logger.LogInformation("Successfully uploaded profile picture. URL: {Url}", profilePictureUrl);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to upload profile picture for user {UserId}", profileCommand.UserId);
                throw;
            }
        }
        else
        {
            logger.LogWarning("No profile picture provided for user {UserId}", profileCommand.UserId);
        }

        var craftsman = mapper.Map<Craftsman>(profileCommand);
        
        craftsman.UserId = profileCommand.UserId;
        
        craftsman.ProfilePicture = profilePictureUrl;

        context.Craftsmen.Add(craftsman);
        
        craftsman.ProfileVerified = true;
        
        await context.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Successfully created craftsman with ID: {CraftsmanId}", craftsman.Id);

        return craftsman.Id;
    }
}
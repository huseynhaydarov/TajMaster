using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TajMaster.Application.Common.Interfaces.BlobStorage;
using TajMaster.Application.Common.Interfaces.CQRS;
using TajMaster.Application.Common.Interfaces.Data;
using TajMaster.Application.Common.Interfaces.IdentityService;
using TajMaster.Application.Exceptions;
using TajMaster.Domain.Entities;
using TajMaster.Domain.Enumerations;

namespace TajMaster.Application.UseCases.Craftsmen.Commands.Create.CompleteCraftsmanProfile;

public class CompleteCraftsmanProfileCommandHandler(
    IApplicationDbContext context,
    IMapper mapper,
    IBlobService blobService,
    IAuthenticatedUserService authenticatedUserService,
    ILogger<CompleteCraftsmanProfileCommandHandler> logger)
    : ICommandHandler<CompleteCraftsmanProfileCommand, Guid>
{
    public async Task<Guid> Handle(CompleteCraftsmanProfileCommand profileCommand, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Starting to process CompleteCraftsmanProfileCommand for UserId: " +
                              "{UserId}", authenticatedUserService.UserId);

        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Id == authenticatedUserService.UserId, cancellationToken);
        
        if (user == null)
        {
            throw new NotFoundException($"User with Id {authenticatedUserService.UserId} not found.");
        }
        
        if (user.UserRoleId != UserRoleEnum.Craftsman.Id && user.UserRoleId != UserRoleEnum.Admin.Id)
        {
            throw new InvalidOperationException("The user is not authorized to complete the craftsman profile.");
        }

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
                logger.LogError(ex, "Failed to upload profile picture for user {UserId}", authenticatedUserService.UserId);
                throw;
            }
        }
        else
        {
            logger.LogWarning("No profile picture provided for user {UserId}", authenticatedUserService.UserId);
        }

        var specialization = await context.Specializations
            .AsNoTracking()
            .FirstOrDefaultAsync(sp => sp.Name.ToLower() == 
                                       profileCommand.Specialization.ToLower(), cancellationToken);

        if (specialization == null)
        {
            throw new NotFoundException($"Specialization with Name {profileCommand.Specialization} not found.");
        }

        var craftsman = mapper.Map<Craftsman>(profileCommand);

        craftsman.SpecializationId = specialization.Id;

        if (authenticatedUserService.UserId != null)
        {
            craftsman.UserId = authenticatedUserService.UserId.Value;
        }
        craftsman.ProfilePicture = profilePictureUrl;
        craftsman.ProfileVerified = true;

        await context.Craftsmen.AddAsync(craftsman, cancellationToken);
        
        await context.SaveChangesAsync(cancellationToken);

        logger.LogInformation("Successfully created craftsman with ID: {CraftsmanId}", craftsman.Id);

        return craftsman.Id;
    }
}

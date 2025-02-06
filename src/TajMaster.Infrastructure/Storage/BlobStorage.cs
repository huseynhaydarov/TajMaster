using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using TajMaster.Application.Common.Interfaces.BlobStorage;

namespace TajMaster.Infrastructure.Storage;

public class BlobService(BlobServiceClient blobServiceClient) : IBlobService
{
    public async Task<string> UploadFileAsync(IFormFile file, string containerName)
    {
        if (file == null)
        {
            throw new ArgumentNullException(nameof(file), "File cannot be null.");
        }

        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        
        await containerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

        var blobClient = containerClient.GetBlobClient(Guid.NewGuid() 
                                                       + Path.GetExtension(file.FileName));

        await using var stream = file.OpenReadStream();
        
        await blobClient.UploadAsync(stream, new BlobHttpHeaders
        {
            ContentType = file.ContentType
        });

        return blobClient.Uri.ToString();
    }
    
    public async Task DeleteFileAsync(string fileUrl, string containerName)
    {
        var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
        
        var blobName = new Uri(fileUrl).Segments[^1];

        var blobClient = containerClient.GetBlobClient(blobName);
        
        await blobClient.DeleteAsync();
    }
}
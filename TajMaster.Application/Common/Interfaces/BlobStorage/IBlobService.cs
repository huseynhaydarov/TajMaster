using Microsoft.AspNetCore.Http;

namespace TajMaster.Application.Common.Interfaces.BlobStorage;

public interface IBlobService
{
    Task<string> UploadFileAsync(IFormFile file, string containerName);
    Task DeleteFileAsync(string fileUrl, string containerName);
}
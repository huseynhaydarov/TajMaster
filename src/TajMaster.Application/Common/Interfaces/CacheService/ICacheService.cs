using Microsoft.Extensions.Caching.Distributed;

namespace TajMaster.Application.Common.Interfaces.CacheService;

public interface ICacheService
{
    Task SetAsync<T>(string key, T value);
    Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options);
    bool TryGetValue<T>(string key, out T? value);
    Task<T?> GetOrSetAsync<T>(string key, Func<Task<T>> task, DistributedCacheEntryOptions? options = null);
}
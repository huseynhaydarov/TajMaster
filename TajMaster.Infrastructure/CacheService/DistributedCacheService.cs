using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Caching.Distributed;
using TajMaster.Application.Common.Interfaces;
using TajMaster.Application.Common.Interfaces.CacheService;

namespace TajMaster.Infrastructure.CacheService;

public class DistributedCacheService(IDistributedCache cache) : ICacheService
{
    private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null,
            WriteIndented = true,
            AllowTrailingCommas = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public Task SetAsync<T>(string key, T value)
        {
            return SetAsync(key, value, new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(30))
                .SetAbsoluteExpiration(TimeSpan.FromHours(1)));
        }

        public Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions options)
        {
            var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, SerializerOptions));
            return cache.SetAsync(key, bytes, options);
        }

        public bool TryGetValue<T>(string key, out T? value)
        {
            var val = cache.Get(key);
            value = default;
            if (val == null) return false;
            value = JsonSerializer.Deserialize<T>(val, SerializerOptions);
            return true;
        }

        public async Task<T?> GetOrSetAsync<T>(string key, Func<Task<T>> task, DistributedCacheEntryOptions? options = null)
        {
            if (options == null)
            {
                options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(30))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1));
            }

            if (TryGetValue(key, out T? value) && value is not null)
            {
                return value;
            }

            value = await task();
            if (value is not null)
            {
                await SetAsync(key, value, options);
            }
            return value;
        }
    }
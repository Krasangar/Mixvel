using Application.AppServices.Cache;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Services;

public class MemoryCacheService(IMemoryCache cache) : ICacheService
{
    public Task SetAsync<TEntry>(string key, IEnumerable<TEntry> entries)
    {
        cache.Set(key, entries);
        return Task.CompletedTask;
    }

    public Task<TEntry?> GetAsync<TEntry>(string key)
    {
        return Task.FromResult(cache.Get<TEntry>(key))!;
    }
}
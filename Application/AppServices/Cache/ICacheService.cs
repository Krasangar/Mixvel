namespace Application.AppServices.Cache;

public interface ICacheService
{
    Task SetAsync<TEntry>(string key,IEnumerable<TEntry> entries);
    Task<TEntry?> GetAsync<TEntry>(string key);
}
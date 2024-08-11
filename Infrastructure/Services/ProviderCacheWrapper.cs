using Application.AppServices;
using Application.AppServices.Cache;
using Application.AppServices.Models;

namespace Infrastructure.Services;

public class ProviderCacheWrapper(IProviderService provider, ICacheService cache) : IProviderService
{
    public async Task<IEnumerable<RouteDto>> GetRoutesAsync(SearchRequest request)
    {
        var key = $"{provider.GetType().Name}_{request.Origin}_{request.Destination}_{request.OriginDateTime.Date}";

        var routes = (request.Filters is { OnlyCached: true }
            ? await cache.GetAsync<IEnumerable<RouteDto>>(key) ?? ArraySegment<RouteDto>.Empty
            : await provider.GetRoutesAsync(request))
            .ToArray();
        
        if (request.Filters is null or { OnlyCached: false })
        {
            await cache.SetAsync(key, routes);
        }

        return routes;
    }
}
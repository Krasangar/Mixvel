using Application.AppServices;
using Application.AppServices.Cache;
using Infrastructure.Services;
using Infrastructure.Services.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IProviderService, ProviderOneService>();
        services.AddTransient<IProviderService, ProviderTwoService>();

        services.Decorate<IProviderService, ProviderCacheWrapper>();

        services.AddMemoryCache();

        services.AddTransient<ICacheService, MemoryCacheService>();
    }
}
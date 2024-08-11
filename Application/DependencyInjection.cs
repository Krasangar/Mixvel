using System.Reflection;
using Application.AppServices;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    private static readonly Assembly Assembly = typeof(DependencyInjection).Assembly;

    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly));
        services.AddFluentValidation(new[] { Assembly });
        services.AddTransient<ISearchService, SearchService>();

    }
}
using Application.AppServices;
using Application.AppServices.Models;
using AutoMapper;
using Infrastructure.Services.Providers.Models.ProviderOne;

namespace Infrastructure.Services.Providers;

public class ProviderOneService(IMapper mapper) : IProviderService
{
    public async Task<IEnumerable<RouteDto>> GetRoutesAsync(SearchRequest request)
    {
        //mock external call
        var response = await Mock(mapper.Map<ProviderOneSearchRequest>(request));

        return mapper.Map<IEnumerable<RouteDto>>(response.Routes);
    }

    private Task<ProviderOneSearchResponse> Mock(ProviderOneSearchRequest request)
    {
        var routes = ProviderOneMockData.Data;
        routes = routes.Where(route => route.From == request.From);
        routes = routes.Where(route => route.To == request.To);


        routes = routes.Where(route => route.DateFrom >= request.DateFrom);

        if (request.MaxPrice.HasValue)
            routes = routes.Where(route => route.Price <= request.MaxPrice);


        if (request.DateTo.HasValue)
            routes = routes.Where(route => route.DateTo <= request.DateTo);


        return Task.FromResult(new ProviderOneSearchResponse
        {
            Routes = routes.ToArray()
        });
    }
}

internal static class ProviderOneMockData
{
    internal static readonly IEnumerable<ProviderOneRoute> Data = new List<ProviderOneRoute>
    {
        new()
        {
            Price = 100,
            From = "moscow",
            To = "sochi",
            DateFrom = DateTime.Now.AddHours(4),
            DateTo = DateTime.Now.AddHours(8),
            TimeLimit = DateTime.Now.AddHours(3)
        },
        new()
        {
            Price = 150,
            From = "moscow",
            To = "sochi",
            DateFrom = DateTime.Now.AddHours(24),
            DateTo = DateTime.Now.AddHours(32),
            TimeLimit = DateTime.Now.AddHours(21)
        },
        new()
        {
            Price = 600,
            From = "moscow",
            To = "yerevan",
            DateFrom = DateTime.Now.AddHours(4),
            DateTo = DateTime.Now.AddHours(8),
            TimeLimit = DateTime.Now.AddHours(3)
        }
    };
}
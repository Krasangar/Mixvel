using Application.AppServices;
using Application.AppServices.Models;
using AutoMapper;
using Infrastructure.Services.Providers.Models.ProviderTwo;

namespace Infrastructure.Services.Providers;

public class ProviderTwoService(IMapper mapper) : IProviderService
{
    public async Task<IEnumerable<RouteDto>> GetRoutesAsync(SearchRequest request)
    {
        //mock external call
        var response = await Mock(mapper.Map<ProviderTwoSearchRequest>(request));

        return mapper.Map<IEnumerable<RouteDto>>(response.Routes);
    }

    private Task<ProviderTwoSearchResponse> Mock(ProviderTwoSearchRequest request)
    {
        var routes = ProviderTwoMockData.Data;
        
        routes = routes.Where(route => route.Departure.Point == request.Departure);
        
        routes = routes.Where(route => route.Arrival.Point == request.Arrival);
        
        routes = routes.Where(route => route.Departure.Date >= request.DepartureDate);
        
        if (request.MinTimeLimit.HasValue)
            routes = routes.Where(route => route.TimeLimit <= request.MinTimeLimit);
        
        return Task.FromResult(new ProviderTwoSearchResponse
        {
            Routes = routes.ToArray()
        });
    }
}

internal static class ProviderTwoMockData
{
    internal static readonly IEnumerable<ProviderTwoRoute> Data = new List<ProviderTwoRoute>
    {
        new()
        {
            Price = 400,
            Departure = new ProviderTwoPoint
            {
                Date = DateTime.Now.AddHours(4),
                Point = "moscow"
            },
            Arrival = new ProviderTwoPoint
            {
                Date = DateTime.Now.AddHours(6),
                Point = "sochi"
            },
            TimeLimit = DateTime.Now.AddHours(2)
        },
        new()
        {
            Price = 350,
            Departure = new ProviderTwoPoint
            {
                Date = DateTime.Now.AddHours(40),
                Point = "moscow"
            },
            Arrival = new ProviderTwoPoint
            {
                Date = DateTime.Now.AddHours(46),
                Point = "sochi"
            },
            TimeLimit = DateTime.Now.AddHours(35)

        },
    };
}
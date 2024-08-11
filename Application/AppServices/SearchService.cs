using Application.AppServices.Models;
using Application.Features.Routes.Models;
using AutoMapper;

namespace Application.AppServices;

public class SearchService(IEnumerable<IProviderService> providers, IMapper mapper) : ISearchService
{
    public async Task<SearchResponse> SearchAsync(SearchRequest request, CancellationToken cancellationToken)
    {
        var routes = (await Task
                .WhenAll(providers.Select(service => service.GetRoutesAsync(request))))
            .SelectMany(routes => routes);

        if (request.Filters != null)
        {
            if (request.Filters.DestinationDateTime.HasValue)
                routes = routes.Where(dto => dto.DestinationDateTime <= request.Filters.DestinationDateTime);

            if (request.Filters.MaxPrice.HasValue)
                routes = routes.Where(dto => dto.Price <= request.Filters.MaxPrice);

            if (request.Filters.MinTimeLimit.HasValue)
                routes = routes.Where(dto => dto.TimeLimit >= request.Filters.MinTimeLimit);
        }


        var routesArray = routes as RouteDto[] ?? routes.ToArray();

        return routesArray.Length != 0
            ? new SearchResponse
            {
                MinPrice = routesArray.MinBy(response => response.Price).Price,
                MaxPrice = routesArray.MaxBy(response => response.Price).Price,
                MinMinutesRoute = (int)Math.Round(routesArray
                    .Select(dto => dto.DestinationDateTime - dto.OriginDateTime).Min()
                    .TotalMinutes),
                MaxMinutesRoute = (int)Math.Round(routesArray
                    .Select(dto => dto.DestinationDateTime - dto.OriginDateTime).Max()
                    .TotalMinutes),
                Routes = routesArray
                    .Select(mapper.Map<RouteModel>).ToArray()
            }
            : new SearchResponse();
    }
}
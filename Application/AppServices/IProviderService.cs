using Application.AppServices.Models;

namespace Application.AppServices;

public interface IProviderService
{
    Task<IEnumerable<RouteDto>> GetRoutesAsync(SearchRequest request);
}
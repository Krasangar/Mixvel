using Application.AppServices.Models;

namespace Application.AppServices;

public interface ISearchService
{
    Task<SearchResponse> SearchAsync(SearchRequest request, CancellationToken cancellationToken);
    Task<bool> IsAvailableAsync(CancellationToken cancellationToken) => Task.FromResult(true);
}
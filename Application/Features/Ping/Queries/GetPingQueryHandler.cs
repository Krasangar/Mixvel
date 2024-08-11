using Application.AppServices;
using MediatR;

namespace Application.Features.Ping.Queries;

public class GetPingQueryHandler(IEnumerable<ISearchService> searchServices) : IRequestHandler<GetPingQuery,bool> 
{
    public async Task<bool> Handle(GetPingQuery request, CancellationToken cancellationToken) =>
        (await Task.WhenAll(searchServices
            .Select(service => service.IsAvailableAsync(cancellationToken))))
        .All(state => state);
}
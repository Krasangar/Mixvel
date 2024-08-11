using Application.AppServices;
using Application.AppServices.Models;
using AutoMapper;
using MediatR;

namespace Application.Features.Routes.Queries;

public class GetRoutesQueryHandler(ISearchService searchService, IMapper mapper)
    : IRequestHandler<GetRoutesQuery, SearchResponse>
{
    public Task<SearchResponse> Handle(GetRoutesQuery query, CancellationToken cancellationToken)
    {
        var request = mapper.Map<SearchRequest>(query);

        return searchService.SearchAsync(request, cancellationToken);
    }
}
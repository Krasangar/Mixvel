using Application.AppServices.Models;
using Application.Features.Routes.Models;
using MediatR;

namespace Application.Features.Routes.Queries;

public class GetRoutesQuery : IRequest<SearchResponse>
{
    public string Origin { get; set; }
    public string Destination { get; set; }
    public DateTime OriginDateTime { get; set; }
    
    public RouteFilterModel? Filters { get; set; }

}
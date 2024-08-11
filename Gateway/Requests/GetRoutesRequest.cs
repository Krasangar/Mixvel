namespace Gateway.Requests;

public record GetRoutesRequest
{
    public string Origin { get; set; }
    public string Destination { get; set; }

    public DateTime OriginDateTime { get; set; }

    public RouteFilterDto? Filters { get; set; }
}
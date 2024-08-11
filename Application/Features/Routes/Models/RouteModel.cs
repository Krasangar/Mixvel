namespace Application.Features.Routes.Models;

public class RouteModel
{
    public Guid Id { get; set; }

    public string Origin { get; set; }

    public string Destination { get; set; }

    public DateTime OriginDateTime { get; set; }

    public DateTime DestinationDateTime { get; set; }

    public decimal Price { get; set; }

    public DateTime TimeLimit { get; set; }
}
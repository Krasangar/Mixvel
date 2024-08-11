namespace Gateway.Requests;

public record RouteFilterDto
{
    public DateTime? DestinationDateTime { get; set; }

    public decimal? MaxPrice { get; set; }

    public DateTime? MinTimeLimit { get; set; }

    public bool? OnlyCached { get; set; }
}
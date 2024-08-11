using Application.Features.Routes.Models;

namespace Application.AppServices.Models;

public class SearchResponse
{
    public RouteModel[] Routes { get; set; }
    public decimal MinPrice { get; set; }
    public decimal MaxPrice { get; set; }
    public int MinMinutesRoute { get; set; }
    public int MaxMinutesRoute { get; set; }
}
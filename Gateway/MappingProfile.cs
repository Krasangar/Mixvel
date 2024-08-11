using Application.AppServices.Models;
using Application.Features.Routes.Models;
using Application.Features.Routes.Queries;
using AutoMapper;
using Gateway.Requests;
using Infrastructure.Services.Providers.Models.ProviderOne;
using Infrastructure.Services.Providers.Models.ProviderTwo;

namespace Gateway;

internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<GetRoutesRequest, GetRoutesQuery>();
        CreateMap<RouteFilterDto, RouteFilterModel>();

        CreateMap<GetRoutesQuery, SearchRequest>();
        CreateMap<RouteFilterModel, SearchFilters>();


        CreateMap<RouteDto, RouteModel>();

        CreateMap<SearchRequest, ProviderOneSearchRequest>()
            .ForMember(request => request.MaxPrice,
                expression => expression.MapFrom(request => request.Filters.MaxPrice))
            .ForMember(request => request.From,
                expression => expression.MapFrom(request => request.Origin))
            .ForMember(request => request.DateFrom,
                expression => expression.MapFrom(request => request.OriginDateTime))
            .ForMember(request => request.DateTo,
                expression => expression.MapFrom(request => request.Filters.DestinationDateTime))
            .ForMember(request => request.To,
                expression => expression.MapFrom(request => request.Destination))
            ;

        CreateMap<ProviderOneRoute, RouteDto>()
            .ForMember(dto => dto.DestinationDateTime,
                expression => expression.MapFrom(route => route.DateTo))
            .ForMember(dto => dto.TimeLimit,
                expression => expression.MapFrom(route => route.TimeLimit))
            .ForMember(dto => dto.OriginDateTime,
                expression => expression.MapFrom(route => route.DateFrom))
            .ForMember(dto => dto.Price,
                expression => expression.MapFrom(route => route.Price))
            .ForMember(dto => dto.Destination,
                expression => expression.MapFrom(route => route.To))
            .ForMember(dto => dto.Origin,
                expression => expression.MapFrom(route => route.From))
            .ForMember(dto => dto.Id,
                expression => expression.MapFrom(route => Guid.NewGuid()))
            ;

        CreateMap<SearchRequest, ProviderTwoSearchRequest>()
            .ForMember(request => request.Arrival, 
                expression => expression.MapFrom(request => request.Destination))
            .ForMember(request => request.MinTimeLimit, 
                expression => expression.MapFrom(request => request.Filters.MinTimeLimit))
            .ForMember(request => request.Departure, 
                expression => expression.MapFrom(request => request.Origin))
            .ForMember(request => request.DepartureDate, 
                expression => expression.MapFrom(request => request.OriginDateTime))
            ;
        
        CreateMap<ProviderTwoRoute, RouteDto>()
            .ForMember(dto => dto.DestinationDateTime,
                expression => expression.MapFrom(route => route.Arrival.Date))
            .ForMember(dto => dto.TimeLimit,
                expression => expression.MapFrom(route => route.TimeLimit))
            .ForMember(dto => dto.OriginDateTime,
                expression => expression.MapFrom(route => route.Departure.Date))
            .ForMember(dto => dto.Price,
                expression => expression.MapFrom(route => route.Price))
            .ForMember(dto => dto.Destination,
                expression => expression.MapFrom(route => route.Arrival.Point))
            .ForMember(dto => dto.Origin,
                expression => expression.MapFrom(route => route.Departure.Point))
            .ForMember(dto => dto.Id,
                expression => expression.MapFrom(route => Guid.NewGuid()))
            ;
    }
}
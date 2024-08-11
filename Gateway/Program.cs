using System.Reflection;
using Application;
using Application.Features.Ping.Queries;
using Application.Features.Routes.Queries;
using AutoMapper;
using Gateway.Requests;
using Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapPost("/routes", async (GetRoutesRequest request, IMediator mediator, IMapper mapper)
        => await mediator.Send(mapper.Map<GetRoutesQuery>(request)))
    .WithOpenApi();

app.MapGet("/ping", async (IMediator mediator) => await mediator.Send(new GetPingQuery()));


app.Run();
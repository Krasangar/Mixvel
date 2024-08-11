using MediatR;

namespace Application.Features.Ping.Queries;

public class GetPingQuery : IRequest<bool>;
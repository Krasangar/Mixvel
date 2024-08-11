using FluentValidation;

namespace Application.Features.Routes.Queries;

public class GetRoutesQueryValidator : AbstractValidator<GetRoutesQuery>
{
    public GetRoutesQueryValidator()
    {
        RuleFor(query => query.Origin).NotEmpty();
        RuleFor(query => query.Destination).NotEmpty();
        RuleFor(query => query.OriginDateTime).NotEmpty();
    }
}
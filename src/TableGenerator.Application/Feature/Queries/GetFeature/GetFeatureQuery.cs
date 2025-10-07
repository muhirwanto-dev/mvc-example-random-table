using ErrorOr;
using MediatR;

namespace TableGenerator.Application.Feature.Queries.GetFeature
{
    public record GetFeatureQuery : IRequest<ErrorOr<Success>>;
}

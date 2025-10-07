using ErrorOr;
using MediatR;
using TableGenerator.Contracts.Dtos.Feature;

namespace TableGenerator.Application.Feature.Commands.AddFeature
{
    public record AddFeatureCommand(
        string Arg
        ) : IRequest<ErrorOr<FeatureResponseDto>>;
}

using ErrorOr;
using MediatR;
using TableGenerator.Application.Interfaces;
using TableGenerator.Contracts.Dtos.Feature;
using TableGenerator.Domain.Core.Entities;

namespace TableGenerator.Application.Feature.Commands.AddFeature
{
    public class AddFeatureCommandHandler(
        IMapper _mapper
        ) : IRequestHandler<AddFeatureCommand, ErrorOr<FeatureResponseDto>>
    {
        public Task<ErrorOr<FeatureResponseDto>> Handle(AddFeatureCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(ErrorOrFactory.From(_mapper.Map<Gender, FeatureResponseDto>(new Gender { Name = "Template added" })));
        }
    }
}

using Riok.Mapperly.Abstractions;
using TableGenerator.Contracts.Dtos.Feature;
using TableGenerator.Domain.Feature.Entities;

namespace TableGenerator.Application.Common.Mapping
{
    public partial class Mapper
    {
        [MapProperty(nameof(Gender.Description), nameof(FeatureResponseDto.Result))]
        [MapperIgnoreSource(nameof(Gender.IsDeleted))]
        [MapperIgnoreSource(nameof(Gender.Id))]
        [MapperIgnoreSource(nameof(Gender.CreatedAt))]
        [MapperIgnoreSource(nameof(Gender.UpdatedAt))]
        private partial FeatureResponseDto MapToFeature(Gender source);
    }
}

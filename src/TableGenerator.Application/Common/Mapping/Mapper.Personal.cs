using Riok.Mapperly.Abstractions;
using TableGenerator.Contracts.Dtos;
using TableGenerator.Domain.Core.Entities;

namespace TableGenerator.Application.Common.Mapping
{
    public partial class Mapper
    {
        [MapperIgnoreTarget(nameof(Personal.GenderId))]
        [MapperIgnoreTarget(nameof(Personal.HobbyId))]
        private partial Personal MapToDomain(PersonalDataRequestDto source);
    }
}

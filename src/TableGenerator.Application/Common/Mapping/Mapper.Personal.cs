using TableGenerator.Contracts.Dtos;
using TableGenerator.Domain.Core.Entities;

namespace TableGenerator.Application.Common.Mapping
{
    public partial class Mapper
    {
        private partial Personal MapToDomain(PersonalDataRequestDto source);
    }
}

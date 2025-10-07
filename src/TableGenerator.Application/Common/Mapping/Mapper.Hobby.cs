using CommunityToolkit.Diagnostics;
using DomainHobby = TableGenerator.Domain.Core.ValueObjects.HobbyType;
using EnumHobby = TableGenerator.Contracts.Enums.Hobby;

namespace TableGenerator.Application.Common.Mapping
{
    public partial class Mapper
    {
        private EnumHobby ConvertDomainToEnum(DomainHobby source)
            => Enum.TryParse<EnumHobby>(source.Name, out var en)
                ? en
                : ThrowHelper.ThrowNotSupportedException<EnumHobby>(source.Value);

        private DomainHobby ConvertEnumToDomain(EnumHobby source)
            => DomainHobby.TryFromName(source.ToString(), out var cat)
                ? cat
                : ThrowHelper.ThrowNotSupportedException<DomainHobby>(source.ToString());
    }
}

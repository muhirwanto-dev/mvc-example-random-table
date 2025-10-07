using CommunityToolkit.Diagnostics;
using DomainGender = TableGenerator.Domain.Core.ValueObjects.GenderType;
using EnumGender = TableGenerator.Contracts.Enums.Gender;

namespace TableGenerator.Application.Common.Mapping
{
    public partial class Mapper
    {
        private EnumGender ConvertDomainToEnum(DomainGender source)
            => Enum.TryParse<EnumGender>(source.Name, out var en)
                ? en
                : ThrowHelper.ThrowNotSupportedException<EnumGender>(source.Value);

        private DomainGender ConvertEnumToDomain(EnumGender source)
            => DomainGender.TryFromName(source.ToString(), out var cat)
                ? cat
                : ThrowHelper.ThrowNotSupportedException<DomainGender>(source.ToString());
    }
}

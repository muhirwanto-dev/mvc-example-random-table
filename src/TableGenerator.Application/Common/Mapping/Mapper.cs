using Riok.Mapperly.Abstractions;
using TableGenerator.Application.Interfaces;

namespace TableGenerator.Application.Common.Mapping
{
    [Mapper(EnumMappingStrategy = EnumMappingStrategy.ByName)]
    public partial class Mapper : IMapper
    {
        public partial TTarget Map<TSource, TTarget>(TSource source);
    }
}

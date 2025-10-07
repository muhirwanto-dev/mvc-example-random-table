using Ardalis.SmartEnum;

namespace TableGenerator.Domain.Core.ValueObjects
{
    public class GenderType(string name, string value) : SmartEnum<GenderType, string>(name, value)
    {
        public static readonly GenderType Man = new GenderType(nameof(Man), "Pria");
        public static readonly GenderType Woman = new GenderType(nameof(Woman), "Wanita");
    }
}

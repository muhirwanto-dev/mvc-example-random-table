using Ardalis.SmartEnum;

namespace TableGenerator.Domain.Core.ValueObjects
{
    public class GenderType(string name, int value) : SmartEnum<GenderType>(name, value)
    {
        public static readonly GenderType Man = new GenderType("Pria", 1);
        public static readonly GenderType Woman = new GenderType("Wanita", 2);
    }
}

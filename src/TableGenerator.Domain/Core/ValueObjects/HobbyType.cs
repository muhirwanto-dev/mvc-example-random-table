using Ardalis.SmartEnum;

namespace TableGenerator.Domain.Core.ValueObjects
{
    public class HobbyType(string name, string value) : SmartEnum<HobbyType, string>(name, value)
    {
        public static readonly HobbyType Football = new HobbyType(nameof(Football), "Sepak Bola");
        public static readonly HobbyType Badminton = new HobbyType(nameof(Badminton), "Badminton");
        public static readonly HobbyType Tennis = new HobbyType(nameof(Tennis), "Tenis");
        public static readonly HobbyType Swimming = new HobbyType(nameof(Swimming), "Renang");
        public static readonly HobbyType Cycling = new HobbyType(nameof(Cycling), "Bersepeda");
        public static readonly HobbyType Sleeping = new HobbyType(nameof(Sleeping), "Tidur");
    }
}

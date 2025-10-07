using Ardalis.SmartEnum;

namespace TableGenerator.Domain.Core.ValueObjects
{
    public class HobbyType(string name, int value) : SmartEnum<HobbyType>(name, value)
    {
        public static readonly HobbyType Football = new HobbyType("Sepak Bola", 1);
        public static readonly HobbyType Badminton = new HobbyType("Badminton", 2);
        public static readonly HobbyType Tennis = new HobbyType("Tenis", 3);
        public static readonly HobbyType Swimming = new HobbyType("Renang", 4);
        public static readonly HobbyType Cycling = new HobbyType("Bersepeda", 5);
        public static readonly HobbyType Sleeping = new HobbyType("Tidur", 6);
    }
}

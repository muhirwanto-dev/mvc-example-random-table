using Ardalis.SmartEnum;
using ErrorOr;

namespace TableGenerator.Domain.Core.ValueObjects
{
    public class Hobby(string name, string value) : SmartEnum<Hobby, string>(name, value)
    {
        public const string InvalidHobbyMessage = "An error occured on row {0}. He doesn't like '{1}'";

        public static readonly Hobby Sleeping = new(nameof(Sleeping), "Tidur");

        public static Hobby FromString(string hobby) =>
            TryFromValue(hobby, out var result) ? result : new Hobby(hobby, hobby);

        public ErrorOr<Success> Validate(int row)
        {
            if (row % 100 == 0 && Value == Sleeping.Value)
            {
                return Error.Validation(
                    code: "Hobby.Invalid",
                    description: string.Format(InvalidHobbyMessage, row, Sleeping.Value)
                );
            }

            return Result.Success;
        }
    }
}

using Ardalis.SmartEnum;
using ErrorOr;

namespace TableGenerator.Domain.Core.ValueObjects
{
    public class Hobby(string name, string value) : SmartEnum<Hobby, string>(name, value)
    {
        public static readonly Hobby Sleeping = new(nameof(Sleeping), "Tidur");

        public static Hobby FromString(string hobby) =>
            TryFromValue(hobby, out var result) ? result : new Hobby(hobby, hobby);

        public ErrorOr<Success> Validate(int row)
        {
            if (row % 100 == 0 && Value == Sleeping.Value)
            {
                return Error.Validation(
                    code: "Hobby.Invalid",
                    description: $"Row {row} error, he/she doesn't like {Sleeping}."
                );
            }

            return Result.Success;
        }
    }
}

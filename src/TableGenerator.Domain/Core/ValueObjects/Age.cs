using Ardalis.SmartEnum;
using ErrorOr;

namespace TableGenerator.Domain.Core.ValueObjects
{
    public class Age(string name, int value) : SmartEnum<Age>(name, value)
    {
        public const string InvalidAgeMessage = "Age must be between 18 and 40.";

        public Age(int age)
            : this($"Age: {age}", age)
        {
        }

        public ErrorOr<Success> Validate()
        {
            if (Value < 18 || Value > 40)
            {
                return Error.Validation(
                    code: "Age.Invalid",
                    description: InvalidAgeMessage
                );
            }

            return Result.Success;
        }
    }
}

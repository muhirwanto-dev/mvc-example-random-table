using Ardalis.SmartEnum;
using ErrorOr;

namespace TableGenerator.Domain.Core.ValueObjects
{
    public class Age(string name, int value) : SmartEnum<Age>(name, value)
    {
        private const int MinAge = 18;
        private const int MaxAge = 40;

        public Age(int age)
            : this($"Age: {age}", age)
        {
        }

        public ErrorOr<Success> Validate()
        {
            if (Value < MinAge || Value > MaxAge)
            {
                return Error.Validation(
                    code: "Age.Invalid",
                    description: $"Age must be between {MinAge} and {MaxAge}."
                );
            }

            return Result.Success;
        }
    }
}

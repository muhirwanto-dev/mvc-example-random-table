using Ardalis.SmartEnum;
using ErrorOr;

namespace TableGenerator.Domain.Core.ValueObjects
{
    public class Age(string name, int value) : SmartEnum<Age>(name, value)
    {
        public static ErrorOr<Age> CreateValidAge(int age)
        {
            if (age < 18 || age > 40)
            {
                return Error.Validation(
                    code: "Age.Invalid",
                    description: "Age must be between 18 and 40."
                );
            }

            return new Age($"{age}", age);
        }
    }
}

using FluentValidation;
using TableGenerator.Contracts.Dtos;
using TableGenerator.Domain.Core.ValueObjects;

namespace TableGenerator.Application.Core.Commands.BulkInsertPersonalData
{
    public class PersonalDataValidator : AbstractValidator<PersonalDataRequestDto>
    {
        public PersonalDataValidator()
        {
            RuleFor(x => x.Age)
                .Must(x =>
                {
                    var age = new Age(x);
                    return age.Validate().Match(
                        onValue: value => true,
                        onError: error => false);
                })
                .WithMessage(Age.InvalidAgeMessage);
        }
    }
}

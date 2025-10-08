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
                .WithMessage(x => new Age(x.Age).Validate().FirstError.Description);

            //RuleFor(x => x)
            //    .Must(x =>
            //    {
            //        var hobby = Hobby.FromString(x.Hobby);
            //        return hobby.Validate(row: x.Id).Match(
            //            onValue: value => true,
            //            onError: error => false);
            //    })
            //    .WithMessage(x =>
            //    {
            //        var hobby = Hobby.FromString(x.Hobby);
            //        return hobby.Validate(x.Id).Match(
            //            onValue: value => string.Empty,
            //            onError: error => error.First().Description);
            //    });
        }
    }
}

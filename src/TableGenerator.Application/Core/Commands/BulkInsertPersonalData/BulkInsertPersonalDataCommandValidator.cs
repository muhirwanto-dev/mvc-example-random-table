using FluentValidation;
using TableGenerator.Application.Core.Commands.BulkInsertPersonalData;

namespace TableGenerator.Application.Core.Commands.AddFeature
{
    public class BulkInsertPersonalDataCommandValidator : AbstractValidator<BulkInsertPersonalDataCommand>
    {
        public BulkInsertPersonalDataCommandValidator()
        {
            RuleForEach(x => x.Data.Payload)
                .SetValidator(new PersonalDataValidator());
        }
    }
}

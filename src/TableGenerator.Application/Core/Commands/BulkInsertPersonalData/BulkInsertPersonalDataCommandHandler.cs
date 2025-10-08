using ErrorOr;
using MediatR;
using TableGenerator.Application.Interfaces.Repositories;

namespace TableGenerator.Application.Core.Commands.BulkInsertPersonalData
{
    public class BulkInsertPersonalDataCommandHandler(
        IPersonalRepository _personalRepository
        ) : IRequestHandler<BulkInsertPersonalDataCommand, ErrorOr<Success>>
    {
        public async Task<ErrorOr<Success>> Handle(BulkInsertPersonalDataCommand request, CancellationToken cancellationToken)
        {
            await _personalRepository.TruncateAsync(cancellationToken);
            await _personalRepository.BulkInsertAsync(request.Data.Payload, cancellationToken);

            return ErrorOrFactory.From(Result.Success);
        }
    }
}

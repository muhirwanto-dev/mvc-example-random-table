using ErrorOr;
using MediatR;
using TableGenerator.Application.Interfaces;

namespace TableGenerator.Application.Core.Commands.BulkInsertPersonalData
{
    public class BulkInsertPersonalDataCommandHandler(
        IMapper _mapper
        ) : IRequestHandler<BulkInsertPersonalDataCommand, ErrorOr<Success>>
    {
        public Task<ErrorOr<Success>> Handle(BulkInsertPersonalDataCommand request, CancellationToken cancellationToken)
        {


            return Task.FromResult(ErrorOrFactory.From(Result.Success));
        }
    }
}

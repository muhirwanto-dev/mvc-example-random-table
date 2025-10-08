using ErrorOr;
using MediatR;
using TableGenerator.Contracts.Dtos;

namespace TableGenerator.Application.Core.Commands.BulkInsertPersonalData
{
    public record BulkInsertPersonalDataCommand(
        BulkInsertPersonalDataRequestDto Data
        ) : IRequest<ErrorOr<Success>>;
}

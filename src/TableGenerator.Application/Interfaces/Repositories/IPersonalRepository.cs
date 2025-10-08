using TableGenerator.Contracts.Dtos;

namespace TableGenerator.Application.Interfaces.Repositories
{
    public interface IPersonalRepository
    {
        Task<int> BulkInsertAsync(IEnumerable<PersonalDataRequestDto> payload, CancellationToken cancellationToken = default);

        Task TruncateAsync(CancellationToken cancellationToken = default);
    }
}

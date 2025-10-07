using TableGenerator.Domain.Core.Entities;

namespace TableGenerator.Application.Interfaces.Repositories
{
    public interface IPersonalRepository
    {
        Task<int> BulkInsertAsync(IEnumerable<Personal> entities, CancellationToken cancellationToken = default);

        Task TruncateAsync(CancellationToken cancellationToken = default);
    }
}

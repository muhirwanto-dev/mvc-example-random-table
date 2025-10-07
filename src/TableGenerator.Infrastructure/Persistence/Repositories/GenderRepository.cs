using SingleScope.Persistence.EFCore.Repository;
using SingleScope.Persistence.Repository;
using TableGenerator.Domain.Core.Entities;
using TableGenerator.Infrastructure.Persistence.Contexts;

namespace TableGenerator.Infrastructure.Persistence.Repositories
{
    internal class GenderRepository : ReadOnlyRepository<Gender, LocalDbContext>, IReadRepository<Gender>
    {
        public GenderRepository(LocalDbContext dbContext) : base(dbContext)
        {
        }
    }
}

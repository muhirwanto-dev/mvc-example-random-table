using SingleScope.Persistence.EFCore.Repository;
using SingleScope.Persistence.Repository;
using TableGenerator.Domain.Core.Entities;
using TableGenerator.Infrastructure.Persistence.Contexts;

namespace TableGenerator.Infrastructure.Persistence.Repositories
{
    internal class HobbyRepository : ReadOnlyRepository<Hobby, LocalDbContext>, IReadRepository<Hobby>
    {
        public HobbyRepository(LocalDbContext dbContext) : base(dbContext)
        {
        }
    }
}

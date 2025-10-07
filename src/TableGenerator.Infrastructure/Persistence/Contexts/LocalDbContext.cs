using Microsoft.EntityFrameworkCore;
using TableGenerator.Domain.Core.Entities;

namespace TableGenerator.Infrastructure.Persistence.Contexts
{
    internal class LocalDbContext : DbContext
    {
        public DbSet<Gender> Genders { get; set; }

        public DbSet<Hobby> Hobbies { get; set; }

        public DbSet<Personal> Personals { get; set; }

        public LocalDbContext(DbContextOptions<LocalDbContext> options) : base(options)
        {
        }
    }
}

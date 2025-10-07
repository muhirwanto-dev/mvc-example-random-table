using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SingleScope.Persistence.Entities;

namespace TableGenerator.Domain.Common.Entities
{
    public abstract class Entity : IEntity
    {
        protected readonly List<IDomainEvent> _domainEvents = [];

        public IList<IDomainEvent> PopDomainEvents()
        {
            var copy = _domainEvents.ToList();

            _domainEvents.Clear();

            return copy;
        }
    }

    public abstract class Entity<TKey> : Entity, IEntity<TKey>
        where TKey : notnull, IEquatable<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; } = default!;
    }
}

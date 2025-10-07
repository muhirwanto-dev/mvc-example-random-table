namespace TableGenerator.Domain.Common.Entities
{
    public abstract class AuditableEntity : NoKeyEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }

    public abstract class AuditableEntity<TKey> : Entity<TKey>
        where TKey : notnull, IEquatable<TKey>
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }
    }
}

namespace TableGenerator.Domain.Common.Entities
{
    public abstract class RecoverableEntity : AuditableEntity
    {
        public bool IsDeleted { get; set; } = false;
    }

    public abstract class RecoverableEntity<TKey> : AuditableEntity<TKey>
        where TKey : notnull, IEquatable<TKey>
    {
        public bool IsDeleted { get; set; } = false;
    }
}

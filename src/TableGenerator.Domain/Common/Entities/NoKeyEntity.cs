using System.ComponentModel.DataAnnotations.Schema;
using SingleScope.Persistence.Entities;

namespace TableGenerator.Domain.Common.Entities
{
    public abstract class NoKeyEntity : Entity, IEntity<int>
    {
        [NotMapped]
        public int Id { get; set; }
    }
}

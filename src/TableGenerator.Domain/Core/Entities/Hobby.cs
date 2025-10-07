using System.ComponentModel.DataAnnotations.Schema;
using TableGenerator.Domain.Common.Entities;

namespace TableGenerator.Domain.Core.Entities
{
    [Table(TableName)]
    public class Hobby : Entity<long>
    {
        public const string TableName = "tblM_hobby";

        public string Name { get; set; } = default!;
    }
}

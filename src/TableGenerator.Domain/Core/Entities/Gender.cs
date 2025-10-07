using System.ComponentModel.DataAnnotations.Schema;
using TableGenerator.Domain.Common.Entities;

namespace TableGenerator.Domain.Core.Entities
{
    [Table(TableName)]
    public class Gender : Entity<long>
    {
        public const string TableName = "tblM_gender";

        public string Name { get; set; } = default!;
    }
}

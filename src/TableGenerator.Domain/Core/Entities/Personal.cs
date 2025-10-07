using System.ComponentModel.DataAnnotations.Schema;
using TableGenerator.Domain.Common.Entities;

namespace TableGenerator.Domain.Core.Entities
{
    [Table(TableName)]
    public class Personal : Entity<long>
    {
        public const string TableName = "tblT_personal";

        public string Name { get; set; } = default!;

        public long GenderId { get; set; }

        public long HobbyId { get; set; }

        public int Age { get; set; }
    }
}

using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TableGenerator.Application.Interfaces.Repositories;
using TableGenerator.Domain.Core.Entities;
using TableGenerator.Infrastructure.Persistence.Contexts;

namespace TableGenerator.Infrastructure.Persistence.Repositories
{
    internal class PersonalRepository(LocalDbContext _context) : IPersonalRepository
    {
        public async Task<int> BulkInsertAsync(IEnumerable<Personal> entities, CancellationToken cancellationToken = default)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(nameof(Personal.Id), typeof(long));
            dataTable.Columns.Add(nameof(Personal.Name), typeof(string));
            dataTable.Columns.Add(nameof(Personal.GenderId), typeof(long));
            dataTable.Columns.Add(nameof(Personal.HobbyId), typeof(long));
            dataTable.Columns.Add(nameof(Personal.Age), typeof(int));

            foreach (var entity in entities)
            {
                dataTable.Rows.Add(
                    entity.Id,
                    entity.Name,
                    entity.GenderId,
                    entity.HobbyId,
                    entity.Age
                );
            }

            var connection = _context.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "dbo.InsertEntitiesBatch";
                command.CommandType = CommandType.StoredProcedure;


                var parameter = new SqlParameter("@Entities", SqlDbType.Structured)
                {
                    TypeName = "dbo.EntityTableType",
                    Value = dataTable,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(parameter);

                var rowsAffected = await command.ExecuteNonQueryAsync(cancellationToken);

                return rowsAffected;
            }
        }

        public async Task TruncateAsync(CancellationToken cancellationToken = default)
        {
            var connection = _context.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync(cancellationToken);
            }

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "dbo.TruncateAllEntities";
                command.CommandType = CommandType.StoredProcedure;

                await command.ExecuteNonQueryAsync(cancellationToken);
            }
        }
    }
}

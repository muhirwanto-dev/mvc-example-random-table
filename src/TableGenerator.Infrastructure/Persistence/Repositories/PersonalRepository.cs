using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TableGenerator.Application.Interfaces.Repositories;
using TableGenerator.Contracts.Dtos;
using TableGenerator.Domain.Core.Entities;
using TableGenerator.Infrastructure.Persistence.Contexts;

namespace TableGenerator.Infrastructure.Persistence.Repositories
{
    internal class PersonalRepository(LocalDbContext _context) : IPersonalRepository
    {
        public async Task<int> BulkInsertAsync(IEnumerable<PersonalDataRequestDto> payload, CancellationToken cancellationToken = default)
        {
            await BulkInsertGenderAsync(payload.Select(x => x.Gender).Distinct(), cancellationToken);
            await BulkInsertHobbyAsync(payload.Select(x => x.Hobby).Distinct(), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var genderEntities = await _context.Genders.ToArrayAsync(cancellationToken);
            var hobbyEntities = await _context.Hobbies.ToArrayAsync(cancellationToken);

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(nameof(Personal.Id), typeof(long));
            dataTable.Columns.Add(nameof(Personal.Name), typeof(string));
            dataTable.Columns.Add(nameof(Personal.GenderId), typeof(long));
            dataTable.Columns.Add(nameof(Personal.HobbyId), typeof(long));
            dataTable.Columns.Add(nameof(Personal.Age), typeof(int));

            foreach (var entity in payload)
            {
                dataTable.Rows.Add(
                    entity.Id,
                    entity.Name,
                    genderEntities.FirstOrDefault(x => x.Name == entity.Gender)?.Id ?? 0,
                    hobbyEntities.FirstOrDefault(x => x.Name == entity.Hobby)?.Id ?? 0,
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
                command.CommandText = "dbo.BulkInsertPersonalData";
                command.CommandType = CommandType.StoredProcedure;

                var parameter = new SqlParameter("@Entities", SqlDbType.Structured)
                {
                    TypeName = "dbo.PersonalTableType",
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
                command.CommandText = "dbo.TruncateAllTables";
                command.CommandType = CommandType.StoredProcedure;

                await command.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        private Task BulkInsertGenderAsync(IEnumerable<string> genders, CancellationToken cancellationToken = default)
        {
            var entities = genders.Select(x => new Gender { Name = x }).ToList();

            return _context.Genders.AddRangeAsync(entities, cancellationToken);
        }

        private Task BulkInsertHobbyAsync(IEnumerable<string> hobbies, CancellationToken cancellationToken = default)
        {
            var entities = hobbies.Select(x => new Hobby { Name = x }).ToList();

            return _context.Hobbies.AddRangeAsync(entities, cancellationToken);
        }
    }
}

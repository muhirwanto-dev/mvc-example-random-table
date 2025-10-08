using System.Data;
using System.Data.Common;
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
            var connection = _context.Database.GetDbConnection();
            if (connection.State != ConnectionState.Open)
            {
                await connection.OpenAsync();
            }

            await BulkInsertGenderAsync(payload.Select(x => x.Gender).Distinct(), connection, cancellationToken);
            await BulkInsertHobbyAsync(payload.Select(x => x.Hobby).Distinct(), connection, cancellationToken);
            return await BulkInsertPersonalAsync(payload, connection, cancellationToken);
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

        private async Task<int> BulkInsertGenderAsync(IEnumerable<string> genders, DbConnection connection, CancellationToken cancellationToken = default)
        {
            var entities = genders.Select(x => new Gender { Name = x }).ToList();
            var data = new DataTable();

            data.Columns.Add("Name", typeof(string));

            foreach (var entity in entities)
            {
                data.Rows.Add(entity.Name);
            }

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "dbo.BulkInsertGenders";
                command.CommandType = CommandType.StoredProcedure;

                var parameter = new SqlParameter("@Data", SqlDbType.Structured)
                {
                    TypeName = "dbo.StringListType",
                    Value = data,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(parameter);

                return await command.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        private async Task<int> BulkInsertHobbyAsync(IEnumerable<string> hobbies, DbConnection connection, CancellationToken cancellationToken = default)
        {
            var entities = hobbies.Select(x => new Hobby { Name = x }).ToList();
            var data = new DataTable();

            data.Columns.Add("Name", typeof(string));

            foreach (var entity in entities)
            {
                data.Rows.Add(entity.Name);
            }

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "dbo.BulkInsertHobbies";
                command.CommandType = CommandType.StoredProcedure;

                var parameter = new SqlParameter("@Data", SqlDbType.Structured)
                {
                    TypeName = "dbo.StringListType",
                    Value = data,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(parameter);

                return await command.ExecuteNonQueryAsync(cancellationToken);
            }
        }

        private async Task<int> BulkInsertPersonalAsync(IEnumerable<PersonalDataRequestDto> personals, DbConnection connection, CancellationToken cancellationToken = default)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(nameof(Personal.Id), typeof(long));
            dataTable.Columns.Add(nameof(Personal.Name), typeof(string));
            dataTable.Columns.Add(nameof(Personal.GenderId), typeof(long));
            dataTable.Columns.Add(nameof(Personal.HobbyId), typeof(long));
            dataTable.Columns.Add(nameof(Personal.Age), typeof(int));

            var genderEntities = await _context.Genders.ToArrayAsync(cancellationToken);
            var hobbyEntities = await _context.Hobbies.ToArrayAsync(cancellationToken);

            foreach (var entity in personals)
            {
                dataTable.Rows.Add(
                    entity.Id,
                    entity.Name,
                    genderEntities.FirstOrDefault(x => x.Name == entity.Gender)?.Id ?? 0,
                    hobbyEntities.FirstOrDefault(x => x.Name == entity.Hobby)?.Id ?? 0,
                    entity.Age
                );
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

                return await command.ExecuteNonQueryAsync(cancellationToken);
            }
        }
    }
}

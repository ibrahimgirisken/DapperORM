using Dapper;
using DapperORM.Application.Interfaces.DapperContext;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common;
using System.Reflection;
using static Dapper.SqlMapper;


namespace DapperORM.Persistence.Repositories
{
    public class DapperGenericRepository<T> : IGenericRepository<T> where T : IBaseEntity
    {
        public IDapperContext _dapperContext;
        public string TableName { get; }

        protected DapperGenericRepository(IDapperContext dapperContext, string tableName)
        {
            this._dapperContext = dapperContext;
            TableName = tableName;
        }
        private async Task<IEnumerable<string>> GetColumnsAsync()
        {
            return typeof(T)
                .GetProperties()
                .Where(e => e.Name != "Id"
                && !e.PropertyType.GetTypeInfo().IsGenericType
                && !Attribute.IsDefined(e, typeof(DapperIgnoreAttribute)))
                .Select(e => e.Name);
        }

        private async Task<IEnumerable<string>> GetColumnsAsync(object data)
        {
            // Ensure non-null data object
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            // Retrieve properties using reflection
            return data.GetType()
                .GetProperties()
                .Where(p =>
                {
                    return p.CanRead &&
                           !p.PropertyType.GetTypeInfo().IsGenericType &&
                           !Attribute.IsDefined(p, typeof(DapperIgnoreAttribute)) &&
                           p.Name != "Id";
                })
                .Select(p => p.Name);
        }

        public async Task<int> AddAsync(T entity)
        {
            var columns = await GetColumnsAsync();
            var stringOfColumns = string.Join(",", columns);
            var stringOfParameters = string.Join(",", columns.Select(e => "@" + e));
            var query = $"insert into {TableName} ({stringOfColumns}) OUTPUT INSERTED.Id values ({stringOfParameters})";

            int insertedId = 0;
            await _dapperContext.ExecuteAsync(async (conn) =>
            {
                insertedId =conn.ExecuteScalar<int>(query, entity);
            });

            return insertedId;
        }
        public async Task DeleteAsync(T entity)
        {
            var query = $"delete from {TableName} where Id=@Id";

           await _dapperContext.ExecuteAsync((conn) =>
            {
                conn.ExecuteAsync(query, entity);
            });
        }

        public async Task<T> GetByIdAsync(int id)
        {

            var query = $"select * from {TableName} where Id = @Id ";

            using (var conn = _dapperContext.GetConnection())
            {
                conn.Open();
                return await conn.QueryFirstAsync<T>(query, new { Id = id });
            }
        }
        public async Task<T> GetByColumnNameAsync(string columnName, string columnValue)
        {
            var query = $"select * from {TableName} where {columnName} = @columnValue";

            using (var conn = _dapperContext.GetConnection())
            {
                conn.Open();
                return await conn.QueryFirstAsync<T>(query, new { columnName = columnValue });
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            var query = $"select * from {TableName}";

            using (var conn = _dapperContext.GetConnection())
            {
                conn.Open();
                var result=await conn.QueryAsync<T>(query);
                return result.ToList();
            }
        }

        public async Task UpdateAsync(T entity)
        {
            var columns = await GetColumnsAsync();
            var stringOfColumns = string.Join(",", columns.Select(e => $"{e}=@{e}"));
            var query = $"update {TableName} set {stringOfColumns} where Id=@Id";

            await _dapperContext.ExecuteAsync((conn) =>
            {
                conn.ExecuteAsync(query, entity);
            });
        }

        public async Task AddRelatedAsync(object data)
        {
            var columnNames = await GetColumnsAsync(data);
            var columnParameters = columnNames.Select(e => "@" + e).ToArray();

            var query = $"insert into {TableName} ({string.Join(",", columnNames)}) values ({string.Join(",", columnParameters)})";

            await _dapperContext.ExecuteAsync((conn) =>
            {
                conn.ExecuteAsync(query, data);
            });
        }

    }
}

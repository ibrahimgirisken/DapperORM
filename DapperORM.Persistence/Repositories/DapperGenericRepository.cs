using Dapper;
using DapperORM.Application.Interfaces.DapperContext;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common;
using System.Reflection;
using static Dapper.SqlMapper;


namespace DapperORM.Persistence.Repositories
{
    public abstract class DapperGenericRepository<T> : IGenericRepository<T> where T : IBaseEntity
    {
        public IDapperContext _dapperContext;
        private string _tableName;

        protected DapperGenericRepository(IDapperContext dapperContext, string tableName)
        {
            this._dapperContext = dapperContext;
            this._tableName = tableName;
        }
        private IEnumerable<string> GetColumns()
        {
            return typeof(T)
                .GetProperties()
                .Where(e => e.Name != "Id"
                && !e.PropertyType.GetTypeInfo().IsGenericType
                && !Attribute.IsDefined(e, typeof(DapperIgnoreAttribute)))
                .Select(e => e.Name);
        }

        private IEnumerable<string> GetColumns(object data)
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

        public async Task<int> Add(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(",", columns);
            var stringOfParameters = string.Join(",", columns.Select(e => "@" + e));
            var query = $"insert into {_tableName} ({stringOfColumns}) OUTPUT INSERTED.Id values ({stringOfParameters})";

            int insertedId = 0;
            _dapperContext.Execute(async (conn) =>
            {
                insertedId =await conn.ExecuteScalarAsync<int>(query, entity);
            });

            return  insertedId;
        }
        public async Task Delete(T entity)
        {
            var query = $"delete from {_tableName} where Id=@Id";

            _dapperContext.Execute((conn) =>
            {
                conn.ExecuteAsync(query, entity);
            });
        }

        public Task<T> Get(int id)
        {

            var query = $"select * from {_tableName} where Id = @Id ";

            using (var conn = _dapperContext.GetConnection())
            {
                conn.Open();
                return conn.QueryFirstAsync<T>(query, new { Id = id });
            }
        }
        public Task<T> GetByColumnName(string columnName, string columnValue)
        {
            var query = $"select * from {_tableName} where {columnName} = @columnValue";

            using (var conn = _dapperContext.GetConnection())
            {
                conn.Open();
                return conn.QueryFirstAsync<T>(query, new { columnName = columnValue });
            }
        }

        public async Task<List<T>> GetAll()
        {
            var query = $"select * from {_tableName}";

            using (var conn = _dapperContext.GetConnection())
            {
                conn.Open();
                var result=await conn.QueryAsync<T>(query);
                return result.ToList();
            }
        }

        public async Task Update(T entity)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(",", columns.Select(e => $"{e}=@{e}"));
            var query = $"update {_tableName} set {stringOfColumns} where Id=@Id";

            _dapperContext.Execute((conn) =>
            {
                conn.ExecuteAsync(query, entity);
            });
        }

        public async Task AddRelated(object data, string tableName)
        {
            var columnNames = GetColumns(data);
            var columnParameters = columnNames.Select(e => "@" + e).ToArray();

            var query = $"insert into {tableName} ({string.Join(",", columnNames)}) values ({string.Join(",", columnParameters)})";

            _dapperContext.Execute((conn) =>
            {
                conn.ExecuteAsync(query, data);
            });
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

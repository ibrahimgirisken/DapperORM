using DapperORM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : IBaseEntity
    {
        Task<T> Get(int id);
        Task<T> GetByColumnName(string columnName,string columnValue);
        Task<int> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task AddRelated(Object Tentity, string tableName);
        Task<List<T>> GetAll();
        Task<T> GetByIdAsync(int id);
    }
}

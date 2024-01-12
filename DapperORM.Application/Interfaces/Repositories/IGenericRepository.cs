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
        Task<T> GetByIdAsync(int id);
        Task<T> GetByColumnNameAsync(string columnName,string columnValue);
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task AddRelatedAsync(Object Tentity, string tableName);
        Task<List<T>> GetAllAsync();
    }
}

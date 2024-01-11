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
        T Get(int id);
        T GetByColumnName(string columnName,string columnValue);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void AddRelated(Object Tentity, string tableName);
        List<T> GetAll();
    }
}

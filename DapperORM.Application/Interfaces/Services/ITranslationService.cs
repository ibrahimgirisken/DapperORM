using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Interfaces.Services
{
    public interface ITranslationService<T,TTranslation> where T : class where TTranslation : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity, IEnumerable<TTranslation> translations);
        Task UpdateAsync(T entity, IEnumerable<TTranslation> translations);
        Task DeleteAsync(int id);
    }
}

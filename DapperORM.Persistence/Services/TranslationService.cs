using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.Interfaces.Services;
using DapperORM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Persistence.Services
{
    public class TranslationService<T, TTranslation> : ITranslationService<T, TTranslation>
     where T : class,IBaseEntity
     where TTranslation : class
    {
        private readonly IGenericRepository<T> _repository;

        public TranslationService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(T entity, IEnumerable<TTranslation> translations)
        {
            await _repository.AddAsync(entity);
            // Additional logic for adding translations if needed
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await _repository.GetByIdAsync(id);
            if (entityToDelete != null)
            {
                await _repository.DeleteAsync(entityToDelete);
                // Additional logic for deleting related translations if needed
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(T entity, IEnumerable<TTranslation> translations)
        {
            await _repository.UpdateAsync(entity);
            // Additional logic for updating translations if needed
        }
    }

}


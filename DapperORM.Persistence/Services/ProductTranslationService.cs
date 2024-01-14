using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.Interfaces.Services;
using DapperORM.Domain.Entities;

namespace DapperORM.Persistence.Services
{
    public class ProductTranslationService : TranslationService<Product, ProductTranslation>, IProductTranslationService
    {
        public ProductTranslationService(IGenericRepository<Product> repository, IGenericRepository<ProductTranslation> repositoryTranslation) : base(repository, repositoryTranslation)
        {
        }
    }
}

using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.Interfaces.Services;
using DapperORM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Persistence.Services
{
    public class ProductTranslationService : TranslationService<Product, ProductTranslation>, IProductTranslationService
    {
        public ProductTranslationService(IGenericRepository<Product> repository) : base(repository)
        {
        }
    }
}

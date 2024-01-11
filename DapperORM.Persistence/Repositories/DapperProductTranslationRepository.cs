using DapperORM.Application.Interfaces.DapperContext;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Persistence.Repositories
{
    public class DapperProductTranslationRepository:DapperGenericRepository<ProductTranslation>,IProductTranslationRepository
    {
        public DapperProductTranslationRepository(IDapperContext dapperContext):base(dapperContext,"ProductTranslations")
        {

        }
    }
}

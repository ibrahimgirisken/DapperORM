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
    public class DapperCategoryRepository : DapperGenericRepository<Category>,ICategoryRepository
    {
        public DapperCategoryRepository(IDapperContext dapperContext):base(dapperContext, "Categories")
        {
        }
    }
}

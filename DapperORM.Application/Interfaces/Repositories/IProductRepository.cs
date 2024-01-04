using DapperORM.Domain.Common;
using DapperORM.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Interfaces.Repositories
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        public List<Product> GetProductByCategoryId(int id);
    }
}

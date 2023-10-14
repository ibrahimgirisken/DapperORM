using Dapper;
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
    public class DapperProductRepository : DapperGenericRepository<Product>, IProductRepository
    {
        public DapperProductRepository(IDapperContext dapperContext) : base(dapperContext,"Products")
        {
        }

        public List<Product> GetProductByCategoryId(int id)
        {
            var query = $"select * from Products where CategoryId={id}";

            using (var conn=_dapperContext.GetConnection())
            {
                conn.Open();
                return (List<Product>)conn.Query<Product>(query);
            }
        }
    }
}

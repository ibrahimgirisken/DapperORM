using Dapper;
using DapperORM.Application.DTOs;
using DapperORM.Application.Interfaces.DapperContext;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Entities;
using System.Data.Entity;
using static Dapper.SqlMapper;

namespace DapperORM.Persistence.Repositories
{
    public class DapperProductRepository : DapperGenericRepository<Product>, IProductRepository
    {
        public DapperProductRepository(IDapperContext dapperContext) : base(dapperContext,"Products")
        {
        }

        public void AddProductAndProductTranslations(ProductToTranslationDto product)
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

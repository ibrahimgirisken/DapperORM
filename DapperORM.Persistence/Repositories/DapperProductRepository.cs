using Dapper;
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

        public void AddRange(Product products)
        {
            var productTranslation = products.Translations.Select(t => new ProductTranslation
            {
                Content = t.Content,
                Title = t.Title,
                MetaDescription = t.MetaDescription,
                MetaKeywords = t.MetaKeywords,
                Name = t.Name,
                LanguageId = t.LanguageId,
                ProductId = t.ProductId,
            });
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

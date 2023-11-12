using AutoMapper;
using DapperORM.Application.Features.Commands.CreateCategory;
using DapperORM.Application.Features.Commands.CreateProduct;
using DapperORM.Application.Features.Commands.RemoveCategory;
using DapperORM.Application.Features.Commands.RemoveProduct;
using DapperORM.Application.Features.Queries.CategoryQueries.GetByIdCategory;
using DapperORM.Application.Features.Queries.ProductQueries.GetByIdProduct;
using DapperORM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.MappingConfiguration
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            //Command
            CreateMap<Product, CreateProductCommandRequest>().ReverseMap();
            CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<Product, RemoveProductCommandRequest>().ReverseMap();
            CreateMap<Category, RemoveCategoryCommandRequest>().ReverseMap();

            //Queries
            CreateMap<Product, GetByIdProductQueryRequest>().ReverseMap();
            CreateMap<Category, GetByIdCategoryQueryRequest>().ReverseMap();
        }
    }
}

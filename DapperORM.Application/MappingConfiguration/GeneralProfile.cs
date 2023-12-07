using AutoMapper;
using DapperORM.Application.Features.Commands.CategoryCommands.CreateCategory;
using DapperORM.Application.Features.Commands.ProductCommands.CreateProduct;
using DapperORM.Application.Features.Commands.CategoryCommands.RemoveCategory;
using DapperORM.Application.Features.Commands.ProductCommands.RemoveProduct;
using DapperORM.Application.Features.Commands.CategoryCommands.UpdateCategory;
using DapperORM.Application.Features.Commands.ProductCommands.UpdateProduct;
using DapperORM.Application.Features.Queries.CategoryQueries.GetAllCategory;
using DapperORM.Application.Features.Queries.CategoryQueries.GetByIdCategory;
using DapperORM.Application.Features.Queries.ProductQueries.GetAllProduct;
using DapperORM.Application.Features.Queries.ProductQueries.GetByIdProduct;
using DapperORM.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DapperORM.Domain.Identity.Models;
using DapperORM.Application.Features.Commands.AppUserCommands.CreateUser;
using DapperORM.Application.Features.Commands.AppUserCommands.LoginUser;

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
            CreateMap<Product, UpdateProductCommandRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommandRequest>().ReverseMap();
            CreateMap<AppUser, CreateUserCommandRequest>().ReverseMap();
            CreateMap<AppUser, LoginUserCommandRequest>().ReverseMap();


            //Queries
            CreateMap<Product, GetAllProductQueryRequest>().ReverseMap();
            CreateMap<Category, GetByIdCategoryQueryRequest>().ReverseMap();
            CreateMap<Product, GetByIdProductQueryRequest>().ReverseMap();
            CreateMap<Category, GetAllCategoryQueryRequest>().ReverseMap();
 
        }
    }
}

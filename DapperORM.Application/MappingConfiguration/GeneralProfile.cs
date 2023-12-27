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
using DapperORM.Application.Features.Commands.AppUserCommands.LoginUser;
using Microsoft.AspNetCore.Identity;

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

            //Queries
            CreateMap<Product, GetAllProductQueryRequest>().ReverseMap();
            CreateMap<Category, GetByIdCategoryQueryRequest>().ReverseMap();
            CreateMap<Product, GetByIdProductQueryRequest>().ReverseMap();
            CreateMap<Category, GetAllCategoryQueryRequest>().ReverseMap();
            CreateMap<IdentityUser, LoginUserCommandRequest>().ReverseMap();
 
        }
    }
}

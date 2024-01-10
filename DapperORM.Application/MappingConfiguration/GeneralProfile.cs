using AutoMapper;
using DapperORM.Application.Features.Commands.CategoryCommands.CreateCategory;
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
using DapperORM.Application.Features.Commands.AppUserCommands.CreateUser;
using DapperORM.Application.DTOs;
using DapperORM.Application.Features.Commands.ProductCommands.CreateProduct;

namespace DapperORM.Application.MappingConfiguration
{
    public class GeneralProfile:Profile
    {
        public GeneralProfile()
        {
            //Command
            CreateMap<Product, RemoveProductCommandRequest>().ReverseMap();
            CreateMap<Product, UpdateProductCommandRequest>().ReverseMap();
            CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, RemoveCategoryCommandRequest>().ReverseMap();
            CreateMap<IdentityUser,CreateUserCommandRequest>().ReverseMap();
            CreateMap<Product,CreateProductCommandRequest>().ReverseMap();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductTranslation, ProductTranslationDto>();


            //Queries
            CreateMap<Product, GetAllProductQueryRequest>().ReverseMap();
            CreateMap<Product, GetByIdProductQueryRequest>().ReverseMap();

            
            CreateMap<Category, GetByIdCategoryQueryRequest>().ReverseMap();
            CreateMap<Category, GetAllCategoryQueryRequest>().ReverseMap();

            CreateMap<IdentityUser, LoginUserCommandRequest>().ReverseMap();
 
        }
    }
}

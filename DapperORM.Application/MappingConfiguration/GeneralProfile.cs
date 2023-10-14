using AutoMapper;
using DapperORM.Application.Features.Commands.CreateProduct;
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

            //Queries
        }
    }
}

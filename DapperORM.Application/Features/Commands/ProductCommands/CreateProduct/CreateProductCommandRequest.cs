﻿using DapperORM.Application.DTOs;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandRequest:IRequest<IDataResult>
    {
        public ProductDto Product { get; set; }

    }
}

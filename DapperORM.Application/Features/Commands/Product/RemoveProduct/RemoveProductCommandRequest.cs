﻿using DapperORM.Domain.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Commands.RemoveProduct
{
    public class RemoveProductCommandRequest:IRequest<IResult>
    {
        public int Id { get; set; }
    }
}

﻿using DapperORM.Domain.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Commands.RemoveCategory
{
    public class RemoveCategoryCommandRequest:IRequest<IResult>
    {
        public int Id { get; set; }
    }
}

using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Quries.GetAllProduct
{
    public class GetAllProductQueryRequest:IRequest<IDataResult<List<Product>>>
    {
    }
}

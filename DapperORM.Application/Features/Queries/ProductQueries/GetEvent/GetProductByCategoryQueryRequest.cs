using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Queries.ProductQueries.GetEvent
{
    public class GetProductByCategoryQueryRequest:IRequest<IDataResult<List<Product>>>
    {
        public int Id { get; set; }
    }
}

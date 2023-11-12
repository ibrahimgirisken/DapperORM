using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Queries.CategoryQueries.GetByIdCategory
{
    public class GetByIdCategoryQueryRequest:IRequest<IDataResult<Category>>
    {
        public int Id { get; set; }
    }
}

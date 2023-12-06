using DapperORM.Domain.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Commands.CategoryCommands.RemoveCategory
{
    public class RemoveCategoryCommandRequest:IRequest<IDataResult>
    {
        public int Id { get; set; }
    }
}

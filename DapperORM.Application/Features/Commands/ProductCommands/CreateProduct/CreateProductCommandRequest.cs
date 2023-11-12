using DapperORM.Domain.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandRequest:IRequest<IResult>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }

    }
}

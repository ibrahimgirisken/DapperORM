using AutoMapper;
using DapperORM.Application.Interfaces.Repositories;
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
    public class GetProductQueryHandler:IRequestHandler<GetProductByCategoryQueryRequest,IDataResult<List<Product>>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IDataResult<List<Product>>> Handle(GetProductByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
           var result=  _productRepository.GetProductByCategoryId(request.Id);
            return Task.FromResult<IDataResult<List<Product>>>(new SuccessDataResult<List<Product>>(result));
        }
    }
    
}

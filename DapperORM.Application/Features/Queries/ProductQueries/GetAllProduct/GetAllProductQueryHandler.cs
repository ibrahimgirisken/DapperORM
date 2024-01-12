using AutoMapper;
using DapperORM.Application.Features.Queries.ProductQueries.GetAllProduct;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Queries.ProductQuesries.GetAllProduct
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, IDataResult<List<Product>>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IDataResult<List<Product>>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            List<Product> products = await _productRepository.GetAll();
            return await Task.FromResult<IDataResult<List<Product>>>(new SuccessDataResult<List<Product>>(products));
        }
    }
}

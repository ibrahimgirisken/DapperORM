using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Queries.ProductQueries.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, IDataResult<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetByIdProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IDataResult<Product>> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var result = _productRepository.Get(request.Id);
            return Task.FromResult<IDataResult<Product>>(new SuccessDataResult<Product>(result));
        }
    }
}

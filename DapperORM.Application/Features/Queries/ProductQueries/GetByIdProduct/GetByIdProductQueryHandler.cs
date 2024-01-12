using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Entities;
using MediatR;

namespace DapperORM.Application.Features.Queries.ProductQueries.GetByIdProduct
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQueryRequest, IDataResult<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetByIdProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IDataResult<Product>> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.Get(request.Id);
            return await Task.FromResult<IDataResult<Product>>(new SuccessDataResult<Product>(result));
        }
    }
}

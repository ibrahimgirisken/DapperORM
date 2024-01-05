using AutoMapper;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandHandler:IRequestHandler<UpdateProductCommandRequest,IDataResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public Task<IDataResult> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product =_mapper.Map<Product>(request);
            _productRepository.Update(product);
            return Task.FromResult<IDataResult>(new SuccessResult(ResultMessages.Product_Updated));
        }
    }
}

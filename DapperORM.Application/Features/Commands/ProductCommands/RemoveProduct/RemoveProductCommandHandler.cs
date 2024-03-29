﻿using AutoMapper;
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

namespace DapperORM.Application.Features.Commands.ProductCommands.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, IDataResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public RemoveProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public Task<IDataResult> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);
            _productRepository.DeleteAsync(product);
            return Task.FromResult<IDataResult>(new SuccessResult(ResultMessages.Product_Deleted));
        }
    }
}

using AutoMapper;
using DapperORM.Application.DTOs;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.Interfaces.Services;
using DapperORM.Application.Validations.Create;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using FluentAssertions;
using MediatR;
using System.Collections.Generic;

namespace DapperORM.Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandHandler:IRequestHandler<CreateProductCommandRequest,IDataResult>
    {
        private readonly IMapper _mapper;
        private readonly CreateProductValidator _createProductValidator;
        public CreateProductCommandHandler(IMapper mapper, CreateProductValidator createProductValidator)
        {
            _mapper = mapper;
            _createProductValidator = createProductValidator;
        }

        public  async Task<IDataResult> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);
            List<ProductTranslation> translations = new();
            var result = _createProductValidator.Validate(product);
            if (result.Errors.Any())
            {
                return await Task.FromResult<IDataResult>(new ErrorResult(ResultMessages.Product_AddedError));
            }
             foreach (var item in request.Product.ProductTranslations)
            {
                ProductTranslation productTranslation =_mapper.Map<ProductTranslation>(item);
                translations.Add(productTranslation);
            }
              return await Task.FromResult<IDataResult>(new SuccessResult(ResultMessages.Product_Added)); 
        }
    }
}

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
        private readonly IProductRepository _productRepository;
        private readonly IProductTranslationRepository _productTranslationRepository;
        private readonly IMapper _mapper;
        private readonly CreateProductValidator _createProductValidator;
        private readonly ITranslationService<Product,ProductTranslation> _translationService;
        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, CreateProductValidator createProductValidator, IProductTranslationRepository productTranslationRepository, ITranslationService<Product, ProductTranslation> translationService)
        {
            _productRepository = productRepository;
            _productTranslationRepository = productTranslationRepository;
            _mapper = mapper;
            _createProductValidator = createProductValidator;
            _translationService = translationService;
        }

        public  async Task<IDataResult> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);
            List<ProductTranslation> translations = new();

             foreach (var item in request.Product.ProductTranslations)
            {
                ProductTranslation productTranslation =_mapper.Map<ProductTranslation>(item);
                translations.Add(productTranslation);
            }      
            
                _translationService.AddAsync(product, translations);
                return await Task.FromResult<IDataResult>(new SuccessResult(ResultMessages.Product_Added)); 
        }
    }
}

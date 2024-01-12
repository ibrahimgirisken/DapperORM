using AutoMapper;
using DapperORM.Application.DTOs;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.Validations.Create;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using MediatR;

namespace DapperORM.Application.Features.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandHandler:IRequestHandler<CreateProductCommandRequest,IDataResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTranslationRepository _productTranslationRepository;
        private readonly IMapper _mapper;
        private readonly CreateProductValidator _createProductValidator;
        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, CreateProductValidator createProductValidator, IProductTranslationRepository productTranslationRepository)
        {
            _productRepository = productRepository;
            _productTranslationRepository = productTranslationRepository;
            _mapper = mapper;
            _createProductValidator = createProductValidator;
        }

        public  async Task<IDataResult> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);
            int response= await _productRepository.AddAsync(product);
            foreach (var item in request.Product.ProductTranslations)
            {
                ProductTranslation productTranslation = _mapper.Map<ProductTranslation>(item);
                productTranslation.ProductId = response;
                _productTranslationRepository.AddAsync(productTranslation);
            }      
                return await Task.FromResult<IDataResult>(new SuccessResult(ResultMessages.Product_Added)); 
        }
    }
}

using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly CreateProductValidator _createProductValidator;
        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, CreateProductValidator createProductValidator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _createProductValidator = createProductValidator;
        }

        public Task<IDataResult> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);
            ProductTranslation productTranslation = _mapper.Map<ProductTranslation>(request.Product.Translations);

            var result = _createProductValidator.Validate(product);
            if (result.Errors.Any())
            {
                return Task.FromResult<IDataResult>(new ErrorResult(result.Errors.First().ErrorMessage));
            }
            _productRepository.Add(product);
            return Task.FromResult<IDataResult>(new SuccessResult(ResultMessages.Product_Added));
        }
    }
}

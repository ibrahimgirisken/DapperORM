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
            var productTranslations = request.Translations.Select(l =>new ProductTranslation
            {
                Language = l.Language,
                Content = l.Content,
                MetaDescription = l.MetaDescription,
                MetaKeywords = l.MetaKeywords,
                LanguageId = l.LanguageId,
                Name = l.Name,
                ProductId = l.ProductId,
                Title = l.Title,
                Product = l.Product

            });
            Product product = _mapper.Map<Product>(request);
            var result = _createProductValidator.Validate(product);
            if (result.Errors.Any())
            {
                return Task.FromResult<IDataResult>(new ErrorResult(result.Errors.First().ErrorMessage));
            }
            _productRepository.Add(product);
            //_productRepository.AddRange(productTranslations);
            return Task.FromResult<IDataResult>(new SuccessResult(ResultMessages.Product_Added));
        }
    }
}

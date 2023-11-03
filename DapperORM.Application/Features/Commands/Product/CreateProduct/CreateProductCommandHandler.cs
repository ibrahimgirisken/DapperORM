using AutoMapper;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.Validations.Create;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using MediatR;

namespace DapperORM.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommandHandler:IRequestHandler<CreateProductCommandRequest,IResult>
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

        public Task<IResult> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);
            var result = _createProductValidator.Validate(product);
            if (result.Errors.Any())
            {
                return Task.FromResult<IResult>(new ErrorResult(result.Errors.First().ErrorMessage));
            }
            _productRepository.Add(product);
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.Product_Added));
        }
    }
}

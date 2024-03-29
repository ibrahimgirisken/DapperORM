﻿using AutoMapper;
using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Application.Validations.Create;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities;
using MediatR;

namespace DapperORM.Application.Features.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommandRequest,IDataResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CreateCategoryValidator _createCategoryValidator;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CreateCategoryValidator createCategoryValidator)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _createCategoryValidator = createCategoryValidator;
        }

        public Task<IDataResult> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category=_mapper.Map<Category>(request);
            var result=_createCategoryValidator.Validate(category);
            if(result.Errors.Any())
            {
                return Task.FromResult<IDataResult>(new ErrorResult(result.Errors.First().ErrorMessage));
            }
            _categoryRepository.AddAsync(category);
            return Task.FromResult<IDataResult>(new SuccessResult(ResultMessages.Category_Added));
        }
    }
}

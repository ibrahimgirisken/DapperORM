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

namespace DapperORM.Application.Features.Commands.CategoryCommands.RemoveCategory
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommandRequest, IDataResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public RemoveCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }



        public Task<IDataResult> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);
            _categoryRepository.DeleteAsync(category);
            return Task.FromResult<IDataResult>(new SuccessResult(ResultMessages.Category_Deleted));
        }
    }
}

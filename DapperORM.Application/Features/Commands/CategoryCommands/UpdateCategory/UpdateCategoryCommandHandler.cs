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

namespace DapperORM.Application.Features.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandHandler:IRequestHandler<UpdateCategoryCommandRequest,IDataResult>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public Task<IDataResult> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);
            _categoryRepository.UpdateAsync(category);
            return Task.FromResult<IDataResult>(new SuccessResult(ResultMessages.Category_Updated));
        }
    }
}

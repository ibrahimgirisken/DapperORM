using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Queries.CategoryQueries.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, IDataResult<List<Category>>>
    {
        readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IDataResult<List<Category>>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var result= await _categoryRepository.GetAllAsync();
            return await Task.FromResult<IDataResult<List<Category>>>(new SuccessDataResult<List<Category>>(result));
        }
    }
}

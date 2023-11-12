using DapperORM.Application.Interfaces.Repositories;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Queries.CategoryQueries.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler: IRequestHandler<GetByIdCategoryQueryRequest, IDataResult<Category>>
    {
        readonly ICategoryRepository _categoryRepository;

        public GetByIdCategoryQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<IDataResult<Category>> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var result = _categoryRepository.Get(request.Id);
            return Task.FromResult<IDataResult<Category>>(new SuccessDataResult<Category>(result));
        }
    }
}

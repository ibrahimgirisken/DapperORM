using DapperORM.Domain.Common.Result;
using MediatR;

namespace DapperORM.Application.Features.Commands.CategoryCommands.CreateCategory
{
    public class CreateCategoryCommandRequest:IRequest<IDataResult>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}

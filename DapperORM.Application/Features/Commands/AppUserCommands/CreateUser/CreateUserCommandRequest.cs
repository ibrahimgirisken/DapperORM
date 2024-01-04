using DapperORM.Domain.Common.Result;
using MediatR;

namespace DapperORM.Application.Features.Commands.AppUserCommands.CreateUser
{
    public class CreateUserCommandRequest : IRequest<IDataResult>
    {
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
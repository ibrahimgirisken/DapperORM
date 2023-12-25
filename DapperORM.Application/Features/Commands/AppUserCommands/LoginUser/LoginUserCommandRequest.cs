using MediatR;

namespace DapperORM.Application.Features.Commands.AppUserCommands.LoginUser
{
    public class LoginUserCommandRequest:IRequest<LoginUserCommandResponse>
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; } 
    }
}

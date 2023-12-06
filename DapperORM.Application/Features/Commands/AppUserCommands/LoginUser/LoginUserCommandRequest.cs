using DapperORM.Application.DTOs;
using DapperORM.Domain.Common.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperORM.Application.Features.Commands.AppUserCommands.LoginUser
{
    public class LoginUserCommandRequest:IRequest<IDataResult<Token>>
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; } 
    }
}

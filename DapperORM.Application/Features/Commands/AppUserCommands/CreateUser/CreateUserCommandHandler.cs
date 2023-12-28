using DapperORM.Application.Abstractions;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace DapperORM.Application.Features.Commands.AppUserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, IDataResult>
    {
        readonly UserManager<IdentityUser> _userManager;
        readonly SignInManager<IdentityUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public CreateUserCommandHandler(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        public async Task<IDataResult> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var _identityUser = new IdentityUser
            {
                UserName = request.UserName,
                PasswordHash = request.PasswordHash,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };
           IdentityResult response =await _userManager.CreateAsync(_identityUser);

            if (response.Succeeded)
            {
            return new SuccessResult(ResultMessages.User_Added);
            }
                 throw new NotImplementedException();
        }
    }

}
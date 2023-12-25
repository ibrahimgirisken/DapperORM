using DapperORM.Application.Abstractions;
using DapperORM.Application.DTOs;
using DapperORM.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DapperORM.Application.Features.Commands.AppUserCommands.LoginUser
{
    public class LoginUserCommandHandler:IRequestHandler<LoginUserCommandRequest,LoginUserCommandResponse>
    {
        readonly AspNetUserManager<IdentityUser> _userManager;
        readonly SignInManager<IdentityUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(AspNetUserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }


        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request,CancellationToken cancellationToken)
        {
            IdentityUser user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            if (user != null)
                user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            if (user == null)
                throw new NotFoundUserException("Kullanıcı veya şifre hatalı!");

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (result.Succeeded)//Authentication başarılı !
            {
                //yetkiler belirlenecek!
                Token token = _tokenHandler.CreateAccessToken(5);
                return new LoginUserSuccessCommandResponse()
                {
                    Token = token
                };
            }
            throw new AuthenticationErrorException();
        }
    }
}

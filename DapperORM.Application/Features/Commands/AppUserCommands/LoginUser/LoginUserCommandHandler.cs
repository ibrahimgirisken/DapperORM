using System;
using DapperORM.Application.Abstractions;
using DapperORM.Application.DTOs;
using DapperORM.Application.Exceptions;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Entities;
using DapperORM.Domain.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DapperORM.Application.Features.Commands.AppUserCommands.LoginUser
{
    public class LoginUserCommandHandler:IRequestHandler<LoginUserCommandRequest,IDataResult<Token>>
    {
       private readonly UserManager<AppUser> _userManager;
       private readonly SignInManager<AppUser> _signInManager;
       private readonly ITokenHandler _tokenHandler;

        public LoginUserCommandHandler(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenHandler tokenHandler)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenHandler = tokenHandler;
        }


        public async Task<IDataResult<Token>> Handle(LoginUserCommandRequest request,CancellationToken cancellationToken)
        {
            AppUser user = await _userManager.FindByNameAsync(request.UserNameOrEmail) ?? await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            if (user == null)
                user=await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            
            if (user == null)
                user=await _userManager.FindByNameAsync(request.UserNameOrEmail);

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if(result.Succeeded)
            {
                Token token =_tokenHandler.CreateAccessToken(5);
                return new SuccessDataResult<Token>(token);
            }
            throw new AuthenticationErrorException();
        }
    }
}

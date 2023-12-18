using AutoMapper;
using DapperORM.Application.Abstractions;
using DapperORM.Application.DTOs;
using DapperORM.Application.Exceptions;
using DapperORM.Application.Identity;
using DapperORM.Domain.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;


namespace DapperORM.Application.Features.Commands.AppUserCommands.LoginUser
{
    public class LoginUserCommandHandler:IRequestHandler<LoginUserCommandRequest,LoginUserCommandResponse>
    {
        //private readonly AspNetUserManager<ErrorViewModel> _userManager;
        //private readonly IMapper _mapper;
        //private readonly SignInManager<ErrorViewModel> _signInManager;
        //private readonly ITokenHandler _tokenHandler;

        //public LoginUserCommandHandler(AspNetUserManager<ErrorViewModel> userManager, SignInManager<ErrorViewModel> signInManager, ITokenHandler tokenHandler, IMapper mapper)
        //{
        //    _userManager = userManager;
        //    _signInManager = signInManager;
        //    _tokenHandler = tokenHandler;
        //    _mapper = mapper;
        //}


        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request,CancellationToken cancellationToken)
        {
            //ErrorViewModel user = await _userManager.FindByNameAsync(request.UserNameOrEmail);
            //if (user == null)
            //    user = await _userManager.FindByEmailAsync(request.UserNameOrEmail);
            //if (user == null)
            //    throw new NotFoundUserException("Kullanıcı veya şifre hatalı!");

            //SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            //if (result.Succeeded)//Authentication başarılı !
            //{
            //    //yetkiler belirlenecek!
            //    Token token = _tokenHandler.CreateAccessToken(5);
            //    return new LoginUserSuccessCommandResponse()
            //    {
            //        Token = token
            //    };
            //}
            throw new AuthenticationErrorException();
        }
    }
}

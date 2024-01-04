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

        public CreateUserCommandHandler(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }



        public async Task<IDataResult> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityUser _user = new IdentityUser
            {
                Email = request.Email,
                UserName = request.UserName,
                PasswordHash = request.Password
            };
           IdentityResult response =await _userManager.CreateAsync(_user,_user.PasswordHash);

            if (response.Succeeded)
           await _userManager.AddToRoleAsync(_user, "Administrator");
            {
            return new SuccessResult(ResultMessages.User_Added);
            }
            return new ErrorResult(response.Errors.Select(e => e.Description).ToString()); // Hata bilgilerini döndürün
        }
    }

}
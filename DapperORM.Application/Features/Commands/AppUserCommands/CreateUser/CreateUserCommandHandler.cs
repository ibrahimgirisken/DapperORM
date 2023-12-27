using DapperORM.Application.Abstractions;
using DapperORM.Domain.Common.Result;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace DapperORM.Application.Features.Commands.AppUserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,IDataResult>
    {
        readonly UserManager<IdentityUser> _userManager;
        readonly SignInManager<IdentityUser> _signInManager;
        readonly ITokenHandler _tokenHandler;

        public CreateUserCommandHandler(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        public Task<IDataResult> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            //ErrorViewModel user = _mapper.Map<ErrorViewModel>(request);
            //var result = _validator.Validate(user);

            //if (result.Errors.Any())
            //{
            //    return Task.FromResult<IDataResult>(new ErrorResult(result.Errors.First().ErrorMessage));
            //}
            //_userRepository.Add(user);
            //return Task.FromResult<IDataResult>(new SuccessResult(ResultMessages.User_Added));
            throw new NotImplementedException();
        }
    }

}

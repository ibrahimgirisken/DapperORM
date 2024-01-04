using AutoMapper;
using DapperORM.Application.Abstractions;
using DapperORM.Application.Validations.Create;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace DapperORM.Application.Features.Commands.AppUserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, IDataResult>
    {
        readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;
        private readonly CreateUserValidator _createUserValidation;

        public CreateUserCommandHandler(UserManager<IdentityUser> userManager, IMapper mapper, CreateUserValidator createUserValidation)
        {
            _userManager = userManager;
            _mapper = mapper;
            _createUserValidation = createUserValidation;
        }



        public async Task<IDataResult> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityUser _user = _mapper.Map<IdentityUser>(request);
            var result = _createUserValidation.Validate(_user);
            if (result.Errors.Any())
            {
                return await Task.FromResult<IDataResult>(new ErrorResult(result.Errors.First().ErrorMessage)); 
            }
           await _userManager.CreateAsync(_user, _user.PasswordHash);
           await _userManager.AddToRoleAsync(_user, "Administrator");
           return await Task.FromResult<IDataResult>(new SuccessResult(ResultMessages.User_Added));
           // Hata bilgilerini döndürün
        }
    }

}
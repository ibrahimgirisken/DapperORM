using AutoMapper;
using DapperORM.Application.Validations.Create;
using DapperORM.Domain.Common.Result;
using DapperORM.Domain.Constants;
using DapperORM.Domain.Entities.Identity;
using MediatR;


namespace DapperORM.Application.Features.Commands.AppUserCommands.CreateUser
{
    public class CreateUserCommandHandler:IRequestHandler<CreateUserCommandRequest,IResult>
    {
        private readonly IMapper _mapper;
        private readonly CreateUserValidator _validator;

        public CreateUserCommandHandler(IMapper mapper, CreateUserValidator validator)
        {
            _mapper = mapper;
            _validator = validator;
        }

        public Task<IResult> Handle(CreateUserCommandRequest request,CancellationToken cancellationToken)
        {
            AppUser user = _mapper.Map<AppUser>(request);
            var result = _validator.Validate(user);

            if(result.Errors.Any())
            {
                return Task.FromResult<IResult>(new ErrorResult(result.Errors.First().ErrorMessage));
            }
            return Task.FromResult<IResult>(new SuccessResult(ResultMessages.User_Added));
        }
    }

}

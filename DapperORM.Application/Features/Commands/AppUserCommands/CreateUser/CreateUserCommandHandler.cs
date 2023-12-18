using DapperORM.Domain.Common.Result;
using MediatR;


namespace DapperORM.Application.Features.Commands.AppUserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,IDataResult>
    {
        //private readonly IUserRepository _userRepository;
        //private readonly IMapper _mapper;
        //private readonly CreateUserValidator _validator;

        //public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, CreateUserValidator validator)
        //{
        //    _userRepository = userRepository;
        //    _mapper = mapper;
        //    _validator = validator;
        //}

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

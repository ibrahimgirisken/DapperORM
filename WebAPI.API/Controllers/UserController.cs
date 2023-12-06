using DapperORM.Application.Features.Commands.AppUserCommands.CreateUser;
using DapperORM.Application.Features.Commands.AppUserCommands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] CreateUserCommandRequest request)
        {
            var result=await _mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result);
                return Ok(result);
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[HttpGet]
        //public async Task<IActionResult> Get([FromQuery] Get)
        //{

        //}

        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            var result = await _mediator.Send(loginUserCommandRequest);
            if(result.IsSuccess == false)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

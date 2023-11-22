using DapperORM.Application.Features.Commands.AppUserCommands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator Mediator;

        public UserController(IMediator mediator)
        {
            Mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] CreateUserCommandRequest request)
        {
            var result=await Mediator.Send(request);
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
    }
}

using DapperORM.Application.Features.Commands.CreateCategory;
using DapperORM.Application.Features.Commands.UpdateCategory;
using DapperORM.Application.Features.Queries.GetAllCategory;
using DapperORM.Application.Features.Queries.GetByIdCategory;
using DapperORM.Application.Features.Queries.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(":id")]
        public async Task<IActionResult> Get([FromQuery] GetCategoryQueryRequest request)
        {
            var result=await _mediator.Send(request);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCategoryQueryRequest request)
        {
            var result= await _mediator.Send(request);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] CreateCategoryCommandRequest request)
        {
            var result=await _mediator.Send(request);
            if(result.IsSuccess==false)
                return BadRequest(result);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] GetByIdCategoryQueryRequest request)
        {
            var result=await _mediator.Send(request);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateCategoryCommandRequest request)
        {
            var result=_mediator.Send(request);
            return Ok(result);
        }
    }
}

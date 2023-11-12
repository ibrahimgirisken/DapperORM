using DapperORM.Application.Features.Commands.CategoryCommands.CreateCategory;
using DapperORM.Application.Features.Commands.CategoryCommands.RemoveCategory;
using DapperORM.Application.Features.Commands.CategoryCommands.UpdateCategory;
using DapperORM.Application.Features.Queries.CategoryQueries.GetAllCategory;
using DapperORM.Application.Features.Queries.CategoryQueries.GetByIdCategory;
using MediatR;
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet(":id")]
        public async Task<IActionResult> Get([FromQuery] GetByIdCategoryQueryRequest request)
        {
            var result = await _mediator.Send(request);
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] CreateCategoryCommandRequest request)
        {
            var result=await _mediator.Send(request);
            if(result.IsSuccess==false)
                return BadRequest(result);
            return Ok(result);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] RemoveCategoryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateCategoryCommandRequest request)
        {
            var result=_mediator.Send(request);
            return Ok(result);
        }
    }
}

using DapperORM.Application.Features.Commands.CreateProduct;
using DapperORM.Application.Features.Commands.RemoveProduct;
using DapperORM.Application.Features.Commands.UpdateProduct;
using DapperORM.Application.Features.Queries.Product.GetEvent;
using DapperORM.Application.Features.Quries.GetAllProduct;
using DapperORM.Application.Features.Quries.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet(":Id")]
        public async Task<IActionResult> Get([FromQuery] GetProductQueryRequest request)
        {
            var result=await _mediator.Send(request);
            //if (result.IsSuccess)
            //    return BadRequest(result);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] CreateProductCommandRequest request)
        {
            var result=await _mediator.Send(request);
            if(result.IsSuccess==false)
                return BadRequest(result);
            return Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] RemoveProductCommandRequest request)
        {
            var result=await _mediator.Send(request);
            //if(result.IsSuccess==false)
            //    return BadRequest(result);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] GetByIdProductQueryRequest request)
        {
            var result= await _mediator.Send(request);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateProductCommandRequest request)
        {
            var result=await _mediator.Send(request);
            //if (result.IsSuccess == false)
            //    return BadRequest(result);
            return Ok(result);
        }
    }
}

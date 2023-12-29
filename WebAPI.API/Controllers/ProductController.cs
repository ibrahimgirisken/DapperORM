using DapperORM.Application.Features.Commands.ProductCommands.CreateProduct;
using DapperORM.Application.Features.Commands.ProductCommands.RemoveProduct;
using DapperORM.Application.Features.Commands.ProductCommands.UpdateProduct;
using DapperORM.Application.Features.Queries.ProductQueries.GetAllProduct;
using DapperORM.Application.Features.Queries.ProductQueries.GetByIdProduct;
using DapperORM.Application.Features.Queries.ProductQueries.GetEvent;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using WebAPI.API.Languages;

namespace WebAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        private readonly IStringLocalizer<Lang> _stringLocalizer;
        public ProductController(IMediator mediator, IStringLocalizer<Lang> stringLocalizer)
        {
            _mediator = mediator;
            _stringLocalizer = stringLocalizer;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("get-lang")]
        public async Task<IActionResult> GetLangData()
        {
            var result = _stringLocalizer["Home"];
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet(":id")]
        public async Task<IActionResult> Get([FromQuery] GetByIdProductQueryRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("get-all-by-category")]
        public async Task<IActionResult> GetProductByCategory([FromQuery] GetProductByCategoryQueryRequest request)
        {
            var result = await _mediator.Send(request);
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> Create([FromQuery] CreateProductCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.IsSuccess == false)
                return BadRequest(result);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] RemoveProductCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateProductCommandRequest request)
        {
            var result = await _mediator.Send(request);
            //if (result.IsSuccess == false)
            //    return BadRequest(result);
            return Ok(result);
        }
    }
}
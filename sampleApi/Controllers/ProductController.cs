using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sampleApi.Application.CQRS.ProductCommandQuery.Command;
using sampleApi.Application.CQRS.ProductCommandQuery.Query;
using sampleApi.Application.Interfaces;
using sampleApi.Infrastructure.Dtos;
using Swashbuckle.AspNetCore.Annotations;

namespace sampleApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public ProductController(IProductService productService,IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }
        
        [SwaggerOperation(
            Summary = "دریافت یک آیتم خاص",
            Description = "این اکشن یک آیتم خاص را با استفاده از ID بازمی‌گرداند.",
            OperationId = "GetItemById",
            Tags = new[] { "Items" }
        )]
        [HttpGet("Id")]
        public async Task<IActionResult> Get([FromQuery]GetProductQuery productQuery)
        {
            var result = await _mediator.Send(productQuery);
            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var result=await _productService.GetAll();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(SaveProductCommand saveProductCommand)
        {
            //var result = await _productService.Add(saveProductCommand.ProductDto);
            var result =await _mediator.Send(saveProductCommand);
            return Ok(result);
        }
    }
}

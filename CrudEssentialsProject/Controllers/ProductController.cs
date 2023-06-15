using CrudEssentialsProject.Interfaces;
using CrudEssentialsProject.Models.Dto;
using CrudEssentialsProject.Services.Enums;
using Microsoft.AspNetCore.Mvc;

namespace CrudEssentialsProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("/")]
        [HttpGet("/product")]
        public async Task<IActionResult> Index()
        {
            var serviceResponse = await _productService.GetAllProducts();

            return Ok(serviceResponse.Message);
        }

        [HttpPost("/product")]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductRequestDto productRequest)
        {
            if (!ModelState.IsValid)
            {
                var errorMessageList = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);

                return BadRequest(errorMessageList);
            }

            var serviceResponse = await _productService.AddNewProduct(productRequest);

            if (serviceResponse.Status == ServiceResponseStatus.BAD_REQUEST)
            {
                return BadRequest(serviceResponse.ErrorMessage);
            }

            return Ok(serviceResponse.Message);
        }

        [HttpGet("/product/{name}")]
        public async Task<IActionResult> QueryProductByName([FromRoute] string name)
        {
            var serviceResponse = await _productService.GetProductByName(name);

            if (serviceResponse.Status == ServiceResponseStatus.NOT_FOUND)
            {
                return NotFound(serviceResponse.ErrorMessage);
            }

            return Ok(serviceResponse.Message);
        }
    }
}

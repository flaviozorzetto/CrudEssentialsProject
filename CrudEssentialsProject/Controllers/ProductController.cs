using CrudEssentialsProject.Interfaces;
using CrudEssentialsProject.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;

namespace CrudEssentialsProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Route("/")]
        [Route("/product")]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts();

            return Ok(products);
        }

        [HttpPost]
        [Route("/product")]
        public async Task<IActionResult> addNewProduct([FromBody] ProductRequest productRequest)
        {
            if (!ModelState.IsValid)
            {
                var errorMessageList = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);

                return BadRequest(errorMessageList);
            }
            try
            {
                var product = await _productService.AddNewProduct(productRequest);

                return Ok(product);
            }
            catch (MySqlException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("/product/{name}")]
        public async Task<IActionResult> queryProductByName([FromRoute] string name)
        {
            var product = await _productService.GetProductByName(name);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }
    }
}

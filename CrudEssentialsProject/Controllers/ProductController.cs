using CrudEssentialsProject.Interfaces;
using CrudEssentialsProject.Models.Dto;
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

        [HttpGet]
        [Route("/product")]
        [Route("/")]
        public IActionResult Index()
        {
            var products = _productService.getAllProducts();

            return Ok(products);
        }

        [HttpPost]
        [Route("/product")]
        public IActionResult addNewProduct([FromBody] ProductRequest productRequest)
        {
            if (!ModelState.IsValid)
            {
                var errorMessageList = ModelState.Values.SelectMany(value => value.Errors).Select(error => error.ErrorMessage);
                return BadRequest(errorMessageList);
            }
            var product = _productService.addNewProduct(productRequest);
            return Ok(product);
        }

        [HttpGet]
        [Route("/product/{name}")]
        public IActionResult queryProductByName([FromRoute] string name)
        {
            var product = _productService.getProductByName(name);
            if (product == null)
            {
                return NotFound("Product not found");
            }
            return Ok(product);
        }
    }
}

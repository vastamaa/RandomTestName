using BackendTest.DTOs;
using BackendTest.Models;
using BackendTest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackendTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("order/{orderId:int}")]
        public async Task<OrderProduct> GetOrderById(int orderId) => await _productsService.GetOrderByIdAsync(orderId);

        [HttpGet("product/{customerId:int}")]
        public async Task<IEnumerable<Product>> GetProductById(int customerId) => await _productsService.GetProductsByCustomerIdAsync(customerId);

        [HttpPost("")]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO)
        {
            var result = await _productsService.AddProductAsync(productDTO);

            if (result > 0) return Ok();

            return BadRequest();
        }
    }
}
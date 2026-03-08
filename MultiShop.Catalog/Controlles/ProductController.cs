using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Common;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;
using static MongoDB.Driver.WriteConcern;

namespace MultiShop.Catalog.Controlles
{


    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {


        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var values = await _productService.GetAllAsync();

            return Ok(ApiResponse<List<ResultProductDto>>.Success(values, "Products retrieved successfully.", 200));

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetProductById(string id)
        {
            var value = await _productService.GetByIdAsync(id);
            return Ok(ApiResponse<GetByIdProductDto>.Success(value, $"Product {value.ProductName} retrieved successfully.", 200));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateAsync(createProductDto);
            return StatusCode(201, ApiResponse.Success($" {createProductDto.ProductName}   created successfully.", 201));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteAsync(id);
            return Ok(ApiResponse.Success($"Product with ID {id} deleted successfully.", 200));
        }

        [HttpPut]

        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateAsync(updateProductDto);
            return Ok(ApiResponse.Success($" {updateProductDto.ProductName} updated successfully.", 200));
        }

       
    }
}

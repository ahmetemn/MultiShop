using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Common;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controlles
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageServices _productImageServices;

        public ProductImagesController(IProductImageServices productImageServices)
        {
            _productImageServices = productImageServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductImages()
        {
            var values = await _productImageServices.GetAllAsync();
            return Ok(ApiResponse<List<ResultProductImageDto>>.Success(values, "Product images retrieved successfully.", 200));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var value = await _productImageServices.GetByIdAsync(id);
            return Ok(ApiResponse<GetByIdProductImageDto>.Success(value, $"Product image retrieved successfully.", 200));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageServices.CreateAsync(createProductImageDto);
            return StatusCode(201, ApiResponse.Success($"{createProductImageDto} created successfully.", 201));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageServices.DeleteAsync(id);
            return Ok(ApiResponse.Success($"Product image with ID {id} deleted successfully.", 200));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageServices.UpdateAsync(updateProductImageDto);
            return Ok(ApiResponse.Success("Product image updated successfully.", 200));
        }
    }
}
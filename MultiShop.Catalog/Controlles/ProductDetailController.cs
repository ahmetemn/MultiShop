using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Common;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controlles
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailServices _productDetailServices;

        public ProductDetailController(IProductDetailServices productDetailServices)
        {
            _productDetailServices = productDetailServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductDetails()
        {
            var values = await _productDetailServices.GetAllAsync();
            return Ok(ApiResponse<List<ResultProductDetailDto>>.Success(values, "Product details retrieved successfully.", 200));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var value = await _productDetailServices.GetByIdAsync(id);
            return Ok(ApiResponse<GetByIdProductDetailDto>.Success(value, "Product detail retrieved successfully.", 200));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailServices.CreateAsync(createProductDetailDto);
            return StatusCode(201, ApiResponse.Success("Product detail created successfully.", 201));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailServices.DeleteAsync(id);
            return Ok(ApiResponse.Success($"Product detail with ID {id} deleted successfully.", 200));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductDetail(string id, UpdateProductDetailDto dto)
        {
            dto.ProductDetailId = id;
            await _productDetailServices.UpdateAsync(dto);
            return Ok(ApiResponse.Success("Product detail updated successfully.", 200));
        }
    }
}
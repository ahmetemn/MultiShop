using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Common;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controlles
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryServices.GetAllAsync();
            return Ok(ApiResponse<List<ResultCategoryDto>>.Success(values, "Categories retrieved successfully.", 200));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var value = await _categoryServices.GetByIdAsync(id);
            return Ok(ApiResponse<GetByIdCategoryDto>.Success(value, $"{value.CategoryName}  retrieved successfully.", 200));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryServices.CreateAsync(createCategoryDto);
            return StatusCode(201, ApiResponse.Success( $"{createCategoryDto.CategoryName} created successfully.", 200));
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryServices.DeleteAsync(id);
            return Ok(ApiResponse.Success("Category deleted successfully.", 200));
        }

        [HttpPut]

        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryServices.UpdateAsync(updateCategoryDto);
            return Ok(ApiResponse.Success("Category updated successfully.", 200));
        }
    }
}

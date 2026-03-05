namespace MultiShop.Catalog.Services.CategoryServices;
public interface ICategoryServices
{
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
    Task<ResultCategoryDto> GetCategoryByIdAsync(string id);
    Task<ResultCategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task<ResultCategoryDto> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);

}
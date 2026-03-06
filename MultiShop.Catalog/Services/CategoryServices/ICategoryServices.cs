
using MultiShop.Catalog.Dtos;

public interface ICategoryServices
{
    Task<List<ResultCategoryDto>> GetAllCategoriesAsync();

    Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);

    Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);

    Task DeleteCategoryAsync(string id);

    Task<GetByIdCategoryDto> GetCategoryByIdAsync(string id);
}
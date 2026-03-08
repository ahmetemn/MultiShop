
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BaseMongoService;

public interface ICategoryServices:
    IGenericMongoService<Category, CreateCategoryDto, UpdateCategoryDto, ResultCategoryDto, GetByIdCategoryDto>
{
    Task<List<ResultCategoryDto>> GetCategoriesByNameAsync(string name);

}
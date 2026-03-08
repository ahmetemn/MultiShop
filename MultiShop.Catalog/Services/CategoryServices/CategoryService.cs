using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BaseMongoService;
using MultiShop.Catalog.Settings;
using MongoDB.Driver.Linq;
namespace MultiShop.Catalog.Services.CategoryServices
{
    public class CategoryService : GenericMongoService<
            Category,
            CreateCategoryDto,
            UpdateCategoryDto,
            ResultCategoryDto,
            GetByIdCategoryDto>,
            ICategoryServices
    {
        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
            : base(mapper, databaseSettings, databaseSettings.CategoryCollectionName)
        {
        }

        public async Task<List<ResultCategoryDto>> GetCategoriesByNameAsync(string name)
        {
            var values = await _collection
                .AsQueryable()
                .Where(x => x.CategoryName.Contains(name))
                .ToListAsync();

            return _mapper.Map<List<ResultCategoryDto>>(values);
        }
    }
}

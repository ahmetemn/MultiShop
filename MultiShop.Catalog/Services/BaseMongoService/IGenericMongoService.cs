
using MultiShop.Catalog.Entities.Abstract;

namespace MultiShop.Catalog.Services.BaseMongoService
{
    public interface IGenericMongoService<TEntity, TCreateDto, TUpdateDto, TResultDto, TGetByIdDto>
        where TEntity : Base
    {
        Task<List<TResultDto>> GetAllAsync();
        Task CreateAsync(TCreateDto createDto);
        Task UpdateAsync(TUpdateDto updateDto);
        Task DeleteAsync(string id);
        Task<TGetByIdDto> GetByIdAsync(string id);
    }
}

using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BaseMongoService;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService:IGenericMongoService<Product, CreateProductDto, UpdateProductDto, ResultProductDto, GetByIdProductDto>
    {
     
    }
}

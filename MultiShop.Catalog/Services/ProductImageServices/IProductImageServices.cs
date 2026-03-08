using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BaseMongoService;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageServices:IGenericMongoService<ProductImage, CreateProductImageDto, UpdateProductImageDto, ResultProductImageDto, GetByIdProductImageDto>
    {


    }
}

using MultiShop.Catalog.Dtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BaseMongoService;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailServices : IGenericMongoService<ProductDetail, CreateProductDetailDto, UpdateProductDetailDto, ResultProductDetailDto, GetByIdProductDetailDto>
    {

    
    }
}

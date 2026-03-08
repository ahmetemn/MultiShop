using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;
using MultiShop.Catalog.Services.BaseMongoService;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailServices
        : GenericMongoService<ProductDetail, CreateProductDetailDto, UpdateProductDetailDto, ResultProductDetailDto, GetByIdProductDetailDto>
        , IProductDetailServices
    {
        public ProductDetailServices(IMapper mapper, IDatabaseSettings databaseSettings)
            : base(mapper, databaseSettings, databaseSettings.ProductDetailCollectionName)
        {
        }
    }
}
using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BaseMongoService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public class ProductImageServices : GenericMongoService<ProductImage, CreateProductImageDto, UpdateProductImageDto, ResultProductImageDto, GetByIdProductImageDto > , IProductImageServices
    {
        public ProductImageServices(IMapper mapper, IDatabaseSettings databaseSettings) : base(mapper, databaseSettings, databaseSettings.ProductImageCollectionName)
        {
        }
    }
}

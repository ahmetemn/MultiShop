using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.BaseMongoService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductService : GenericMongoService<Product, CreateProductDto, UpdateProductDto, ResultProductDto, GetByIdProductDto>, IProductService
    {
        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings) : base(mapper, databaseSettings, databaseSettings.ProductCollectionName)
        {
        }
    }
}

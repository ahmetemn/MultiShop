using MultiShop.Catalog.Entities.Abstract;

namespace MultiShop.Catalog.Dtos.ProductDtos;

public class UpdateProductDto
{

    public string Id { get; set; }
    public string ProductName { get; set; }
    public decimal Price { get; set; }
    public string  ProductImageUrl { get; set; }
    public string ProductDescription { get; set; }

    public string  CategoryId { get; set; }
}
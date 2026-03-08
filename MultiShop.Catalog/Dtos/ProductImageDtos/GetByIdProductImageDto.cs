using MultiShop.Catalog.Entities.Abstract;

namespace MultiShop.Catalog.Dtos.ProductImageDtos;

public class GetByIdProductImageDto
{

    public string Id { get; set; }
    public List<string> Images { get; set; } = new();

    public string ProductId  { get; set; }
}
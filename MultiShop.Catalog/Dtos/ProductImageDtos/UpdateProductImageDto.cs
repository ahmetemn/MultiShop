namespace MultiShop.Catalog.Dtos.ProductImageDtos;

public class UpdateProductImageDto
{
    public string ProductImageId { get; set; }

    public List<string> Images { get; set; } = new();

    public string ProductId  { get; set; }
}
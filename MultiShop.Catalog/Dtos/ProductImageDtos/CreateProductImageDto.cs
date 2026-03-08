namespace MultiShop.Catalog.Dtos.ProductImageDtos;

public class CreateProductImageDto
{

    public List<string> Images { get; set; } = new();

    public string ProductId  { get; set; }
}
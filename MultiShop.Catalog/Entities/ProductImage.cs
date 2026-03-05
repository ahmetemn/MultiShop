namespace MultiShop.Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ProductImage
{

    public ProductImage(string productImageId ,  string productId)
    {
        ProductImageId = productImageId;
        ProductId = productId;
    }
    
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ProductImageId { get; set; }

    public string? Image1 { get; set; }
    public string? Image2 { get; set; }

    public string? Image3 { get; set; }

    public string ProductId  { get; set; }
    [BsonIgnore]
    public Product?  Product { get; set; }
}
namespace MultiShop.Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class ProductDetail
{
    public ProductDetail( string productDetailId)
    {
        ProductDetailId = productDetailId; 
    }
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    
    public string  ProductDetailId { get; set; }
    public string?  ProductDescription { get; set; }
    public string?  ProductInfo { get; set; }

    public string ProductId  { get; set; }
    
    [BsonIgnore]
    public Product Product  { get; set; }
    
}